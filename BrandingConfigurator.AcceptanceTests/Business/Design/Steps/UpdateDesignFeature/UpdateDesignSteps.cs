using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Steps.UpdateDesignFeature;

public class UpdateDesignSteps
{
    private const string UserId = "UserTestId";
    private const string Resource = "Resource";
    private const string ImageName = "logo.pdf";
    private const string SupplierItemId = "21069017";
    private const string OtherSupplierItemId = "38106940";
    private readonly IDesignService _designService;
    private readonly IImageService _imageService;
    private readonly IProductService _productService;
    private Model.Design _initialDesign;
    private Model.Design _fetchedDesign;
    private string _designId;
    private Exception _responseException;
    private string _imageId = "";

    public UpdateDesignSteps(
        IDesignService designService,
        IImageService imageService,
        IProductService productService)
    {
        _designService = designService;
        _imageService = imageService;
        _productService = productService;
    }

    public void CreateDesign()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesign();

        CreateDesignWithImage();
    }

    public void CreateDesignWithoutDecorations()
    {
        _initialDesign = PrepareDesignWithoutDecorations();
        _designId = _designService.CreateDesign(_initialDesign, UserId);
        Assert.IsNotNull(_designId);
    }

    public void GetDesign()
    {
        _fetchedDesign = _designService.GetDesign(_designId, UserId);
    }

    public void GetDesignWithoutUserId()
    {
        try
        {
            _designService.GetDesign(_designId, "");
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void UpdateDesign()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesign();
        _initialDesign.Id = _designId;
        _designService.UpdateDesign(_initialDesign, UserId);
    }

    public void UpdateDesignWithoutUserId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesign();
        _initialDesign.Id = _designId;

        try
        {
            _designService.UpdateDesign(_initialDesign, "");
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void UpdateTheDesignByDesignWithoutDecorations()
    {
        _initialDesign = PrepareDesignWithoutDecorations();
        _initialDesign.Id = _designId;
        _designService.UpdateDesign(_initialDesign, UserId);
    }

    public void UpdateTheDesignByDesignWithWrongPrintAreaId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongPrintAreaId();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongPrintTechniqueId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongPrintTechniqueId();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithLogoOutsideOfPrintArea()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithLogoOutsideOfPrintArea();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongSupplierItemId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongSupplierItemId();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongComponentId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongComponentId();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithVariants();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongIdsOfVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongVariantsId();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongModelOfVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongVariantsModel();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfAngleOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfAngleOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfCenterPointOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfAngleOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfWidthOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfWidthOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfHeightOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfHeightOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfScaledXOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfScaledXOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void UpdateTheDesignByDesignWithWrongValueOfScaledYOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfScaledYOfLogo();
        _initialDesign.Id = _designId;

        CallUpdateDesignRequest();
    }

    public void TheDesignIsProvided()
    {
        Assert.IsNotNull(_initialDesign);
        Assert.IsNotNull(_fetchedDesign);
        Assert.That(_initialDesign.SupplierItemId, Is.EqualTo(_fetchedDesign.SupplierItemId));
        Assert.That(_initialDesign.Decorations.Count(), Is.EqualTo(_fetchedDesign.Decorations.Count()));
        var decorations =
            _initialDesign.Decorations.Zip(_fetchedDesign.Decorations, (n, w) => new { inital = n, fetched = w });
        foreach (var decoration in decorations)
        {
            Assert.That(decoration.inital.PrintAreaId, Is.EqualTo(decoration.fetched.PrintAreaId));
            Assert.That(decoration.inital.PrintTechniqueId, Is.EqualTo(decoration.fetched.PrintTechniqueId));
            Assert.That(decoration.inital.Layers.Count(), Is.EqualTo(decoration.fetched.Layers.Count()));
            var layers =
                decoration.inital.Layers.Zip(decoration.fetched.Layers, (n, w) => new { inital = n, fetched = w });
            foreach (var layer in layers)
            {
                Assert.That(layer.inital.ComponentId, Is.EqualTo(layer.fetched.ComponentId));
                Assert.That(layer.inital.ComponentType, Is.EqualTo(layer.fetched.ComponentType));
                Assert.That(layer.inital.Coordinates.TopLeftX, Is.EqualTo(layer.fetched.Coordinates.TopLeftX));
                Assert.That(layer.inital.Coordinates.TopLeftY, Is.EqualTo(layer.fetched.Coordinates.TopLeftY));
                Assert.That(layer.inital.Coordinates.TopRightX, Is.EqualTo(layer.fetched.Coordinates.TopRightX));
                Assert.That(layer.inital.Coordinates.TopRightY, Is.EqualTo(layer.fetched.Coordinates.TopRightY));
                Assert.That(layer.inital.Coordinates.BottomLeftX, Is.EqualTo(layer.fetched.Coordinates.BottomLeftX));
                Assert.That(layer.inital.Coordinates.BottomLeftY, Is.EqualTo(layer.fetched.Coordinates.BottomLeftY));
                Assert.That(layer.inital.Coordinates.BottomRightX, Is.EqualTo(layer.fetched.Coordinates.BottomRightX));
                Assert.That(layer.inital.Coordinates.BottomRightY, Is.EqualTo(layer.fetched.Coordinates.BottomRightY));
            }
        }
    }

    public void TheDesignIsUpdated()
    {
        TheDesignIsProvided();
    }

    private void CreateDesignWithImage()
    {
        _designId = _designService.CreateDesign(_initialDesign, UserId);
        Assert.IsNotNull(_designId);
        TestRunContext.GetInstance().DesignId = _designId;
    }

    public void TheDesignIsNotUpdated()
    {
        Assert.AreEqual("Invalid service response. Expected code NoContent, retrieved BadRequest",
            _responseException.Message);
    }

    private void CallUpdateDesignRequest()
    {
        try
        {
            _designService.UpdateDesign(_initialDesign, UserId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    private string UploadImageFile()
    {
        return _imageService.UploadImage(ReadImage(), ImageName, UserId);
    }

    private Model.Design PrepareDesign()
    {
        var product = FetchProduct(SupplierItemId);

        return PrepareDesignModel(product);
    }

    private Model.Design PrepareDesignWithWrongPrintAreaId()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.PrintAreaId = "foo";

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongPrintTechniqueId()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.PrintTechniqueId = "foo";

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongSupplierItemId()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.SupplierItemId = "foo";

        return designModel;
    }

    private Model.Design PrepareDesignWithLogoOutsideOfPrintArea()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.Coordinates.TopLeftX -= 10;

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongComponentId()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.ComponentId = "foo";

        return designModel;
    }

    private Model.Design PrepareDesignWithVariants()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Variants = new List<Variant>
        {
            new()
            {
                SupplierItemId = product.SupplierItemId ?? "",
                Quantity = 1
            }
        };

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongVariantsId()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Variants = new List<Variant>
        {
            new()
            {
                SupplierItemId = "wrongSupplierItemId",
                Quantity = 1
            }
        };

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongVariantsModel()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Variants = new List<Variant>
        {
            new()
            {
                SupplierItemId = OtherSupplierItemId,
                Quantity = 1
            }
        };

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongValueOfAngleOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.Angle = 361;

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongValueOfWidthOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.Width = -1;

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongValueOfHeightOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.Height = -1;

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongValueOfScaledXOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.ScaledX = -1;

        return designModel;
    }

    private Model.Design PrepareDesignWithWrongValueOfScaledYOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.ScaledY = -1;

        return designModel;
    }

    private Product.Model.Product FetchProduct(string supplierItemId)
    {
        return _productService.GetProduct(supplierItemId, "SEK").Result;
    }

    private Model.Design PrepareDesignModel(Product.Model.Product product)
    {
        return new Model.Design
        {
            SupplierItemId = product.SupplierItemId ?? "",
            Decorations = (product.PrintAreas ?? Array.Empty<PrintArea>()).Select(printArea => new Decoration
            {
                PrintAreaId = printArea.ReferenceId ?? "",
                PrintTechniqueId = printArea.PrintTechniques?.FirstOrDefault()?.MethodCode ?? "",
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
                        }
                    }
                }
            }).ToList()
        };
    }

    private static Model.Design PrepareDesignWithoutDecorations()
    {
        return new Model.Design
        {
            SupplierItemId = SupplierItemId,
            Decorations = new List<Decoration>()
        };
    }

    private static MemoryStream ReadImage()
    {
        return new MemoryStream(System.IO.File.ReadAllBytes(
            Path.Combine(Path.GetFullPath(AppContext.BaseDirectory), Resource, ImageName)));
    }
}