using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Steps.CreateDesignFeature;

public class CreateDesignSteps
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

    public CreateDesignSteps(
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

    public void CreateDesignWithoutUserId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesign();

        try
        {
            _designId = _designService.CreateDesign(_initialDesign, "");
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void CreateDesignWithoutDecorations()
    {
        _initialDesign = PrepareDesignWithoutDecorations();
        _designId = _designService.CreateDesign(_initialDesign, UserId);
        Assert.IsNotNull(_designId);
    }

    public void CreateDesignWithEmptyDecoration()
    {
        _initialDesign = PrepareDesignWithEmptyDecoration();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongPrintAreaId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongPrintAreaId();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongPrintTechniqueId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongPrintTechniqueId();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongSupplierItemId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongSupplierItemId();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithLogoOutsideOfPrintArea()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithLogoOutsideOfPrintArea();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithLogoEdgePointsOutsideOfPrintArea()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithLogoEdgePointsOutsideOfPrintArea();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongComponentId()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongComponentId();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithVariants();

        CreateDesignWithImage();
    }

    public void CreateDesignWithWrongIdOfVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongVariantsId();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongModelOfVariants()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongVariantsModel();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfAngleOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfAngleOfLogo();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfCenterPointOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfCenterPointOfLogo();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfWidthOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfWidthOfLogo();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfHeightOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfHeightOfLogo();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfScaledXOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfScaledXOfLogo();

        CallCreateDesignRequest();
    }

    public void CreateDesignWithWrongWrongValueOfScaledYOfLogo()
    {
        _imageId = UploadImageFile();
        _initialDesign = PrepareDesignWithWrongValueOfScaledYOfLogo();

        CallCreateDesignRequest();
    }

    public void GetDesign()
    {
        _fetchedDesign = _designService.GetDesign(_designId, UserId);
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

    public void TheDesignIsNotCreated()
    {
        Assert.AreEqual("Invalid service response. Expected code Created, retrieved BadRequest",
            _responseException.Message);
    }

    private void CreateDesignWithImage()
    {
        _designId = _designService.CreateDesign(_initialDesign, UserId);
        Assert.IsNotNull(_designId);
        TestRunContext.GetInstance().DesignId = _designId;
    }

    private void CallCreateDesignRequest()
    {
        try
        {
            _designId = _designService.CreateDesign(_initialDesign, UserId);
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

    private Model.Design PrepareDesignWithLogoEdgePointsOutsideOfPrintArea()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!.EdgePoints = new List<BasePoint<int>>
        {
            new(-10, -20)
        };

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

    private Model.Design PrepareDesignWithWrongValueOfCenterPointOfLogo()
    {
        var product = FetchProduct(SupplierItemId);
        var designModel = PrepareDesignModel(product);

        var layer = designModel.Decorations.FirstOrDefault()!.Layers.FirstOrDefault()!;
        layer.CenterPoint = new BasePoint<decimal>(layer.Coordinates.TopRightX + 10, layer.Coordinates.TopRightY + 10);

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

    private static Model.Design PrepareDesignWithEmptyDecoration()
    {
        return new Model.Design
        {
            SupplierItemId = SupplierItemId,
            Decorations = new List<Decoration>
            {
                new()
            }
        };
    }

    private static MemoryStream ReadImage()
    {
        return new MemoryStream(System.IO.File.ReadAllBytes(
            Path.Combine(Path.GetFullPath(AppContext.BaseDirectory), Resource, ImageName)));
    }
}