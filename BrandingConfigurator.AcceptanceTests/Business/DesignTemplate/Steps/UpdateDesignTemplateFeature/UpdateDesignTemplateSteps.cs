using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using NUnit.Framework;
using System.Globalization;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.UpdateDesignTemplateFeature;

public class UpdateDesignTemplateSteps
{
    private const string Resource = "Resource";
    private const string ImageName = "logo.pdf";
    private const string SupplierItemId = "21069017";
    private readonly IDesignService _designService;
    private readonly IDesignTemplateService _designTemplateService;
    private readonly IImageService _imageService;
    private readonly IProductService _productService;
    private static readonly string Timestamp =
        DateTime.Now.ToString("_yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
    private string _name = "DesignTemplateName" + Timestamp;
    private readonly string _userId = "UserTestId" + Timestamp;
    private Design.Model.Design _design;
    private string _designTemplateId;
    private string _designId;
    private string _designIdWithDifferentSupplierItemId;
    private Exception _responseException;
    private string _imageId = "";

    public UpdateDesignTemplateSteps(
        IDesignService designService,
        IDesignTemplateService designTemplateService,
        IImageService imageService,
        IProductService productService)
    {
        _designService = designService;
        _designTemplateService = designTemplateService;
        _imageService = imageService;
        _productService = productService;
    }

    public void CreateDesignTemplateWithUniqueName()
    {
        CreateUniqueDesignTemplateName();
        CreateDesign();
        CreateDesignTemplate(_name);
    }

    public void CreateDesignAndDesignTemplateWithoutSupplierItemIdNotMatching()
    {
        CreateDesign();
        CreateDesignWithDifferentSupplierItemId();
        CreateDesignTemplate(_name + "2");
    }

    public void UpdateDesignTemplate()
    {
        MakeChangeInDesign();
        try
        {
            _designTemplateService.UpdateDesignTemplate(_designId, _designTemplateId, _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void UpdateDesignTemplateWithDesignWithNotMatchingSupplierItemId()
    {
        try
        {
            _designTemplateService.UpdateDesignTemplate(_designIdWithDifferentSupplierItemId, _designTemplateId, _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void UpdateDesignTemplateThatDoesNotExist()
    {
        try
        {
            _designTemplateService.UpdateDesignTemplate(_designId, "foo", _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void UpdateDesignTemplateWithDesignThatDoesNotExist()
    {
        try
        {
            _designTemplateService.UpdateDesignTemplate("foo", _designTemplateId, _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void DesignTemplateIsUpdated()
    {
        var designTemplate = _designTemplateService.GetDesignTemplate(_designTemplateId, _userId);
        Assert.IsNotNull(designTemplate);
        Assert.That(designTemplate.Decorations.FirstOrDefault().Layers.FirstOrDefault().Coordinates.TopLeftX, Is.EqualTo(30));
    }

    public void DesignTemplateIsNotUpdated()
    {
        Assert.That(_responseException.Message, Is.EqualTo("Invalid service response. Expected code NoContent, retrieved BadRequest"));
    }

    private void CreateDesign()
    {
        _imageId = UploadImageFile();
        _design = PrepareDesign();
        _designId = _designService.CreateDesign(_design, _userId);
        Assert.IsNotNull(_designId);
    }

    private void CreateDesignWithDifferentSupplierItemId()
    {
        _imageId = UploadImageFile();
        _design = PrepareDesignWithDifferentSupplierItemId();
        _designIdWithDifferentSupplierItemId = _designService.CreateDesign(_design, _userId);
        Assert.IsNotNull(_designIdWithDifferentSupplierItemId);
    }

    private void CreateDesignTemplate(string? name = null)
    {
        _designTemplateId = _designService.CreateDesignTemplate(_designId, name, _userId);
    }

    private string UploadImageFile()
    {
        return _imageService.UploadImage(ReadImage(), ImageName, _userId);
    }

    private static MemoryStream ReadImage()
    {
        return new MemoryStream(System.IO.File.ReadAllBytes(
            Path.Combine(Path.GetFullPath(AppContext.BaseDirectory), Resource, ImageName)));
    }

    private Design.Model.Design PrepareDesign()
    {
        var product = FetchProduct(SupplierItemId);

        return PrepareDesignModel(product);
    }

    private Design.Model.Design PrepareDesignWithDifferentSupplierItemId()
    {
        var product = FetchProduct("37538010");

        return PrepareDesignModel(product);
    }

    private void MakeChangeInDesign()
    {
        _design.Decorations.FirstOrDefault().Layers.FirstOrDefault().Coordinates.TopLeftX = 30;
        _design.Id = _designId;
        _designService.UpdateDesign(_design, _userId);
    }

    private Product.Model.Product FetchProduct(string supplierItemId)
    {
        return _productService.GetProduct(supplierItemId, "SEK").Result;
    }

    private Design.Model.Design PrepareDesignModel(Product.Model.Product product)
    {
        return new Design.Model.Design
        {
            SupplierItemId = product.SupplierItemId ?? "",
            Decorations = (product.PrintAreas ?? Array.Empty<PrintArea>()).Select(printArea => new Decoration
            {
                PrintAreaId = printArea.ReferenceId ?? "",
                PrintTechniqueId = printArea.PrintTechniques.FirstOrDefault().MethodCode ?? "",
                Layers = new List<Layer>
                {
                    new()
                    {
                        ComponentType = ComponentType.Image,
                        ComponentId = _imageId,
                        Coordinates = new Coordinates
                        {
                            TopLeftX = (int)(printArea.CoordinateTopLeftX + 1),
                            TopLeftY = (int)(printArea.CoordinateTopLeftY + 1),
                            TopRightX = (int)(printArea.CoordinateTopRightX - 1),
                            TopRightY = (int)(printArea.CoordinateTopRightY + 1),
                            BottomLeftX = (int)(printArea.CoordinateBottomLeftX + 1),
                            BottomLeftY = (int)(printArea.CoordinateBottomLeftY - 1),
                            BottomRightX = (int)(printArea.CoordinateBottomRightX - 1),
                            BottomRightY = (int)(printArea.CoordinateBottomRightY - 1)
                        },
                        EdgePoints = new List<BasePoint<int>>()
                    }
                }
            }).ToList()
        };
    }

    private void CreateUniqueDesignTemplateName()
    {
        _name = "Test" + DateTime.Now.ToString("_yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
    }
}