using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Model;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Globalization;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.GetDesignTemplatesFeature;

public class GetDesignTemplatesSteps
{
    private const string OtherUserId = "OtherUserId";
    private const string OtherName = "OtherName";
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
    private readonly string _userIdForPagedDesignTemplates = "UserTestId2" + Timestamp;
    private Design.Model.Design _design;
    private IEnumerable<Model.DesignTemplate> _designTemplates;
    private string _designTemplateId;
    private string _designTemplateId2;
    private string _designId;
    private Exception _responseException;
    private string _imageId = "";
    private Paging _paging = new Paging();

    public GetDesignTemplatesSteps(
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

    public void CreateTwoDesignTemplatesWithName()
    {
        CreateDesignForPagedDesignTemplates();
        CreateTwoDesignTemplates(_name);
    }

    public void GetDesignTemplates()
    {
        _designTemplates = _designTemplateService.GetDesignTemplates(_userId, null);
    }

    public void GetPagedDesignTemplates()
    {
        _paging.PageNumber = 2;
        _paging.PageSize = 1;
        _designTemplates = _designTemplateService.GetDesignTemplates(_userIdForPagedDesignTemplates, _paging);
    }

    public void GetDesignTemplatesForOtherUserId()
    {
        _designTemplates = _designTemplateService.GetDesignTemplates(OtherUserId, null);
    }

    public void GetDesignTemplatesByNameForUserId()
    {
        _designTemplates = _designTemplateService.GetDesignTemplates(_userId, null, _name);
    }

    public void GetDesignTemplatesByOtherNameForUserId()
    {
        _designTemplates = _designTemplateService.GetDesignTemplates(_userId, null, OtherName);
    }

    public void GetDesignTemplatesForUserIdAndLocale(string locale)
    {
        _designTemplates = _designTemplateService.GetDesignTemplates(_userId, null, locale, null);
    }

    public void DesignTemplatesAreProvided()
    {
        var designTemplates = _designTemplates.Where(x => x.Id == _designTemplateId);
        AssertTranslation();
        Assert.AreEqual(1, designTemplates.Count());
        AssertDesignTemplate(_design, designTemplates.First());
    }

    public void PagedDesignTemplatesAreProvided()
    {
        Assert.AreEqual(1, _designTemplates.Count());
        Assert.That(_designTemplates.FirstOrDefault().Id, Is.EqualTo(_designTemplateId2));
        AssertDesignTemplate(_design, _designTemplates.First());
    }

    public void DesignTemplatesAreNotProvided()
    {
        Assert.AreEqual(0, _designTemplates.Count());
    }

    public void DesignTemplatesAreProvidedAndTranslated(string locale)
    {
        var designTemplates = _designTemplates.Where(x => x.Id == _designTemplateId);
        AssertTranslation(locale);
        Assert.AreEqual(1, designTemplates.Count());
        AssertDesignTemplate(_design, designTemplates.First());
    }

    private void CreateDesign()
    {
        _imageId = UploadImageFile();
        _design = PrepareDesign();
        _designId = _designService.CreateDesign(_design, _userId);
        Assert.IsNotNull(_designId);
    }

    private void CreateDesignForPagedDesignTemplates()
    {
        _imageId = UploadImageFileForPagedDesignTemplates();
        _design = PrepareDesign();
        _designId = _designService.CreateDesign(_design, _userIdForPagedDesignTemplates);
        Assert.IsNotNull(_designId);
    }

    private void CreateDesignTemplate(string? name = null)
    {
        _designTemplateId = _designService.CreateDesignTemplate(_designId, name, _userId);
    }

    private void CreateTwoDesignTemplates(string? name = null)
    {
        _designTemplateId = _designService.CreateDesignTemplate(_designId, name, _userIdForPagedDesignTemplates);
        _designTemplateId2 = _designService.CreateDesignTemplate(_designId, name + "2", _userIdForPagedDesignTemplates);
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

    private string UploadImageFile()
    {
        return _imageService.UploadImage(ReadImage(), ImageName, _userId);
    }

    private string UploadImageFileForPagedDesignTemplates()
    {
        return _imageService.UploadImage(ReadImage(), ImageName, _userIdForPagedDesignTemplates);
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
        if (locale == "sv_SE")
        {
            Assert.That(_designTemplates.FirstOrDefault().Decorations.FirstOrDefault().LocationName, Is.EqualTo("runt"));
            Assert.That(_designTemplates.FirstOrDefault().Decorations.FirstOrDefault().MethodName, Is.EqualTo("roterande screentryck"));
        }
        else
        {
            Assert.That(_designTemplates.FirstOrDefault().Decorations.FirstOrDefault().LocationName, Is.EqualTo("wrap"));
            Assert.That(_designTemplates.FirstOrDefault().Decorations.FirstOrDefault().MethodName, Is.EqualTo("Screenround"));
        }
    }
}