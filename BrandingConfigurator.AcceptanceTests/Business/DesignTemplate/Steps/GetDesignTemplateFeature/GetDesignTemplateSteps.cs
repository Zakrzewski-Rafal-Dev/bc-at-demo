using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Globalization;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.GetDesignTemplateFeature;

public class GetDesignTemplateSteps
{
    private const int MaxAttemptsForDesignTemplatePreviewsGeneration = 20;
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
    private Model.DesignTemplate _designTemplate;
    private string _designTemplateId;
    private string _designId;
    private Exception _responseException;
    private string _imageId = "";

    public GetDesignTemplateSteps(
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

    public void GetDesignTemplate()
    {
        try
        {
            _designTemplate = _designTemplateService.GetDesignTemplate(_designTemplateId, _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void GetDesignTemplateForOtherUserId()
    {
        try
        {
            _designTemplate = _designTemplateService.GetDesignTemplate("otherDesignTemplateId", _userId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void GetDesignTemplateForOtherUserIdAndLocale(string locale)
    {
        try
        {
            _designTemplate = _designTemplateService.GetDesignTemplate(_designTemplateId, _userId, locale);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void DesignTemplateWithNameAndDefaultLanguageIsProvided()
    {
        AssertDesignTemplate(_design, _designTemplate);
        AssertTranslation();
        Assert.That(_designTemplate.Name, Is.EqualTo(_name));
        AssertDesignTemplatePreview();
    }

    public void DesignTemplateWithNameIsProvidedAndTranslated(string locale)
    {
        AssertDesignTemplate(_design, _designTemplate);
        AssertTranslation(locale);
        Assert.That(_designTemplate.Name, Is.EqualTo(_name));
        AssertDesignTemplatePreview();
    }

    public void DesignTemplateIsNotProvided()
    {
        Assert.AreEqual("Invalid service response. Expected code OK, retrieved NotFound",
            _responseException.Message);
    }

    private void CreateDesign()
    {
        _imageId = UploadImageFile();
        _design = PrepareDesign();
        _designId = _designService.CreateDesign(_design, _userId);
        Assert.IsNotNull(_designId);
    }

    private void CreateDesignTemplate(string? name = null)
    {
        _designTemplateId = _designService.CreateDesignTemplate(_designId, name, _userId);
    }

    private void AssertDesignTemplate(Design.Model.Design design, Model.DesignTemplate designTemplate)
    {
        Assert.IsNotNull(design);
        Assert.IsNotNull(designTemplate);
        Assert.That(designTemplate.SupplierItemId, Is.EqualTo(design.SupplierItemId));
        Assert.That(designTemplate.Decorations.Count(), Is.EqualTo(design.Decorations.Count()));
        for (int i = 0; i < designTemplate.Decorations.Count(); i++)
        {
            var designDecoration = design.Decorations.ToList()[i];
            var designTemplateDecoration = designTemplate.Decorations.ToList()[i];
            Assert.That(designDecoration.PrintAreaId, Is.EqualTo(designTemplateDecoration.PrintAreaId));
            Assert.That(designDecoration.PrintTechniqueId, Is.EqualTo(designTemplateDecoration.PrintTechniqueId));
            var serializedLayersInDesign = JsonConvert.SerializeObject(designDecoration.Layers);
            var serializedLayersInDesignTemplate = JsonConvert.SerializeObject(designTemplateDecoration.Layers);
            Assert.That(serializedLayersInDesign, Is.EqualTo(serializedLayersInDesignTemplate));
        }
    }

    private void AssertDesignTemplatePreview()
    {
        for (var i = 0; i < MaxAttemptsForDesignTemplatePreviewsGeneration; i++)
        {
            if (!string.IsNullOrEmpty(_designTemplate.PreviewPath))
            {
                AssertValueOfDesignTemplatePreviews(_designTemplate);
                return;
            }
            Thread.Sleep(1000);
            GetDesignTemplate();
        }
        Assert.Fail("Design template preview was not generated in time");
    }

    private static void AssertValueOfDesignTemplatePreviews(Model.DesignTemplate designTemplate)
    {
        for (var i = 0; i < designTemplate.Decorations.Count(); i++)
        {
            var designTemplateDecoration = designTemplate.Decorations.ToList()[i];
            Assert.That(designTemplateDecoration.PreviewPath, Does.StartWith("/file/Image/"));
        }

        Assert.That(designTemplate.PreviewPath, Does.StartWith("/file/Preview/"));
        Assert.That(designTemplate.PreviewPath, Does.EndWith(".pdf"));
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

    private void AssertTranslation(string locale = "")
    {
        if(locale == "sv_SE")
        {
            Assert.That(_designTemplate.Decorations.FirstOrDefault().LocationName, Is.EqualTo("runt"));
            Assert.That(_designTemplate.Decorations.FirstOrDefault().MethodName, Is.EqualTo("roterande screentryck"));
        }
        else
        {
            Assert.That(_designTemplate.Decorations.FirstOrDefault().LocationName, Is.EqualTo("wrap"));
            Assert.That(_designTemplate.Decorations.FirstOrDefault().MethodName, Is.EqualTo("Screenround"));
        }
    }
}