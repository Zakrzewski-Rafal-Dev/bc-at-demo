using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Service;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice;

public class PrintPriceSteps
{
    private const int PreferentialThreshold = 500;
    private const int StandardLeadTimeQuantity = 1000;
    private const int OneDayLeadTime = 1;

    private static List<int> ProductQuantitiesBelowPreferentialThreshold =>
        new() { -10, -1, 0, 1, 250, 499, PreferentialThreshold };

    private static List<int> ProductQuantitiesAbovePreferentialThreshold => new()
        { PreferentialThreshold + 1, 599, 1000, 1001, 1999, 2000, 3000, 10000 };

    private const string UserId = "UserTestId";
    private const string Resource = "Resource";
    private const string ImageName = "logo.pdf";
    private const int PositiveQuantityOfProducts = 2;
    private const int ZeroQuantityOfProducts = 0;
    private const int NegativeQuantityOfProducts = -2;
    private const int QuantityOfSetups = 1;
    private const string WrongDesignId = "wrongDesignId";
    private const string WrongCurrency = "wrongCurrency";
    private const string SupplierItemIdWithPrintAreaWhosePrintPriceIsFixed = "21069017";
    private readonly List<string> _variantSupplierItemIdsWithPrintAreaWhosePrintPriceIsFixed = new() { "21069017" };
    private const string SupplierItemIdWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo = "38106940";

    private readonly List<string> _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo =
        new() { "38106941" };

    private const string SupplierItemIdWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors = "38106940";

    private readonly List<string> _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors =
        new() { "38106941" };

    private const string PrintCodeOfPrintTechniqueWithPrintPriceDependOnTheNumberOfColors = "TRAT03";
    private const string PrintCodeOfPrintTechniqueWithPrintPriceDependOnTheSizeOfTheLogo = "DTRTS01";
    private const string PrintCodeOfPrintTechniqueWithFixedPrintPrice = "DST03";
    private const string SupplierItemIdWithLeadTimeConfiguration = "38106940";
    private const string PrintCodeOfPrintTechniqueWithLeadTimeConfiguration = "TRAT03";
    private const string AdditionalPrintCodeOfPrintTechniqueWithLeadTimeConfiguration = "DTRTS01";
    private readonly IPrintPriceService _printPriceService;
    private readonly IDesignService _designService;
    private readonly IImageService _imageService;
    private readonly IProductService _productService;
    private DesignPrintPriceForVariants _designPrintPriceForVariants = new();
    private DesignPrintPrice _designPrintPrice = new();
    private Design.Model.Design _design = new();
    private Exception? _responseException;
    private string _designId = "";
    private string _imageId = "";
    private readonly Dictionary<int, int> _leadTimeForQuantity = new();

    public PrintPriceSteps(
        IPrintPriceService printPriceService,
        IDesignService designService,
        IImageService imageService,
        IProductService productService)
    {
        _printPriceService = printPriceService;
        _designService = designService;
        _imageService = imageService;
        _productService = productService;
    }

    public void UploadImage()
    {
        _imageId = _imageService.UploadImage(ReadImage(), ImageName, UserId);
    }

    public void CreateDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo()
    {
        _design = PrepareDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo();
        _designId = CreateDesign();
    }

    public void CreateDesignWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors()
    {
        _design = PrepareDesignModelWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors();
        _designId = CreateDesign();
    }

    public void CreateDesignWithPrintAreaWhosePrintPriceIsFixed()
    {
        _design = PrepareDesignModelWithPrintAreaWhosePrintPriceIsFixed();
        _designId = CreateDesign();
    }

    public void CreateAnEmptyDesign()
    {
        _design = PrepareEmptyDesign();
        _designId = CreateDesign();
    }

    public void CreateAnDesignWithOnePrintAreaAndOnePrintTechnique()
    {
        _design = PrepareCreateAnDesignWithOnePrintAreaAndOnePrintTechnique();
        _designId = CreateDesign();
    }

    public void CreateAnDesignWithManyPrintAreasAndOnePrintTechnique()
    {
        _design = PrepareCreateAnDesignWithManyPrintAreasAndOnePrintTechnique();
        _designId = CreateDesign();
    }

    public void CreateAnDesignWithManyPrintAreasAndManyPrintTechniques()
    {
        _design = PrepareCreateAnDesignWithManyPrintAreasAndManyPrintTechniques();
        _designId = CreateDesign();
    }

    public void CalculatePrintPriceInSek()
    {
        CalculatePrintPrice(Currency.SEK.ToString());
    }

    public void CalculatePrintPriceInEur()
    {
        CalculatePrintPrice(Currency.EUR.ToString());
    }

    public void CalculatePrintPriceInWrongCurrency()
    {
        CalculatePrintPrice(WrongCurrency);
    }

    public void CalculatePrintPriceForNotExistingDesign()
    {
        try
        {
            _designPrintPriceForVariants =
                _printPriceService.CalculatePrintPrice(WrongDesignId, new VariantsForPrintPrices(), UserId);
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void CalculatePrintPriceForZeroProductQuantity()
    {
        _designPrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, ZeroQuantityOfProducts, Currency.SEK.ToString(), UserId);
    }

    public void CalculatePrintPriceForNegativeProductQuantity()
    {
        _designPrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, NegativeQuantityOfProducts, Currency.SEK.ToString(),
                UserId);
    }

    public void CalculatePrintPriceWithoutProductQuantity()
    {
        _designPrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, (int?)null, Currency.SEK.ToString(), UserId);
    }

    public void PrintPriceInEurIsValid()
    {
        PrintPriceIsValid(Currency.EUR);
    }

    public void PrintPriceInSekIsValid()
    {
        PrintPriceIsValid(Currency.SEK);
    }

    public void PrintPriceForVariantsInEurIsValid()
    {
        PrintPriceForVariantsIsValid(Currency.EUR);
    }

    public void PrintPriceForVariantsInSekIsValid()
    {
        PrintPriceForVariantsIsValid(Currency.SEK);
    }

    public void PrintPriceIsZero()
    {
        Assert.IsNotNull(_designPrintPrice);
        Assert.That(_designPrintPrice.Total, Is.EqualTo(0));
        Assert.That(_designPrintPrice.TotalCostPrice, Is.EqualTo(0));
        Assert.That(_designPrintPrice.SetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPrice.CostSetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPrice.ProductsPrintPrice, Is.EqualTo(0));
        Assert.That(_designPrintPrice.ProductsCostPrintPrice, Is.EqualTo(0));
        Assert.That(_designPrintPrice.UnitSetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPrice.UnitCostSetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPrice.UnitPrintPrice, Is.EqualTo(0));
        Assert.That(_designPrintPrice.UnitCostPrintPrice, Is.EqualTo(0));
        Assert.That(_designPrintPrice.QuantityOfSetups, Is.EqualTo(0));
        Assert.That(_designPrintPrice.Currency, Is.Null);
        Assert.That(_designPrintPrice.QuantityOfProducts, Is.EqualTo(0)); 
        Assert.That(_designPrintPrice.DesignId, Is.EqualTo(_designId));
        Assert.That(_designPrintPrice.LeadTime, Is.EqualTo(0));
        Assert.IsNotNull(_designPrintPrice.DecorationPrintPrices);
        Assert.That(_designPrintPrice.DecorationPrintPrices!.Count, Is.EqualTo(0));
    }

    public void ZeroPrintPriceAndNoVariantsIsReturned()
    {
        Assert.IsNotNull(_designPrintPriceForVariants);
        Assert.That(_designPrintPriceForVariants.TotalSalesPrice, Is.EqualTo(0));
        Assert.Null(_designPrintPriceForVariants.Currency);
        Assert.That(_designPrintPriceForVariants.Variants?.Count(), Is.EqualTo(0));
        Assert.That(_designPrintPriceForVariants.DesignId, Is.EqualTo(_designId));
        Assert.That(_designPrintPriceForVariants.SalesSetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPriceForVariants.ProductsSalesPrintPrice, Is.EqualTo(0));
    }

    public void ZeroPrintPriceForVariantsIsReturned()
    {
        Assert.IsNotNull(_designPrintPriceForVariants);
        Assert.That(_designPrintPriceForVariants.TotalSalesPrice, Is.EqualTo(0));
        Assert.Null(_designPrintPriceForVariants.Currency);
        Assert.That(_designPrintPriceForVariants.Variants?.Count(), Is.EqualTo(1));
        Assert.That(_designPrintPriceForVariants.DesignId, Is.EqualTo(_designId));
        Assert.That(_designPrintPriceForVariants.SalesSetupCharge, Is.EqualTo(0));
        Assert.That(_designPrintPriceForVariants.ProductsSalesPrintPrice, Is.EqualTo(0));
    }

    public void LeadTimeIsAlwaysZero()
    {
        foreach (var value in _leadTimeForQuantity.Values)
        {
            Assert.That(value, Is.EqualTo(0));
        }
    }

    public void LeadTimeIsOneDay()
    {
        foreach (var key in _leadTimeForQuantity.Keys)
        {
            Assert.That(_leadTimeForQuantity[key],
                key <= 0 ? Is.EqualTo(0) : Is.EqualTo(OneDayLeadTime));
        }
    }

    public void StandardLeadTimeIsReturned()
    {
        foreach (var key in _leadTimeForQuantity.Keys)
        {
            Assert.That(_leadTimeForQuantity[key], Is.EqualTo(CalculateExpectedStandardLeadTime(key)));
        }
    }

    public void ExtendedOneLeadTimeIsReturned()
    {
        foreach (var key in _leadTimeForQuantity.Keys)
        {
            Assert.That(_leadTimeForQuantity[key], Is.EqualTo(CalculateExpectedExtendedOneLeadTime(key)));
        }
    }

    public void ExtendedStandardLeadTimeIsReturned()
    {
        foreach (var key in _leadTimeForQuantity.Keys)
        {
            Assert.That(_leadTimeForQuantity[key], Is.EqualTo(CalculateExpectedExtendedStandardLead(key)));
        }
    }

    public void CombinedStandardLeadTimeIsReturned()
    {
        foreach (var key in _leadTimeForQuantity.Keys)
        {
            Assert.That(_leadTimeForQuantity[key], Is.EqualTo(CalculateExpectedCombinedStandardLeadTime(key)));
        }
    }

    public void PrintPricesAreNotGiven()
    {
        Assert.AreEqual("Invalid service response. Expected code OK, retrieved BadRequest", _responseException.Message);
    }

    private static int CalculateExpectedStandardLeadTime(int key)
    {
        return key % StandardLeadTimeQuantity == 0
            ? StandardLeadTimeForFullStandardLeadTimeQuantity(key)
            : StandardLeadTimeForNotFullStandardLeadTimeQuantity(key);
    }

    private static int CalculateExpectedExtendedOneLeadTime(int key)
    {
        const int numberOfPrintTechniques = 2;
        return key <= 0 ? 0 : OneDayLeadTime * numberOfPrintTechniques;
    }

    private static int CalculateExpectedExtendedStandardLead(int key)
    {
        const int additionalValue = 1;
        return key % StandardLeadTimeQuantity == 0
            ? StandardLeadTimeForFullStandardLeadTimeQuantity(key) + additionalValue
            : StandardLeadTimeForNotFullStandardLeadTimeQuantity(key) + additionalValue;
    }

    private static int CalculateExpectedCombinedStandardLeadTime(int key)
    {
        if (key <= 0)
        {
            return 0;
        }

        const int numberOfPrintTechniques = 2;
        return key % StandardLeadTimeQuantity == 0
            ? StandardLeadTimeForFullStandardLeadTimeQuantity(key) * numberOfPrintTechniques
            : StandardLeadTimeForNotFullStandardLeadTimeQuantity(key) * numberOfPrintTechniques;
    }

    private static int StandardLeadTimeForFullStandardLeadTimeQuantity(int key)
    {
        return key / StandardLeadTimeQuantity + 1;
    }

    private static int StandardLeadTimeForNotFullStandardLeadTimeQuantity(int key)
    {
        return key / StandardLeadTimeQuantity + 2;
    }

    private void CalculatePrintPrice(string currency)
    {
        _designPrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, PositiveQuantityOfProducts, currency, UserId);
    }

    private void CalculatePrintPriceForVariants(string currency)
    {
        var variant = _design.Variants.Select(variant => new VariantForPrintPrices
        {
            SupplierItemId = variant.SupplierItemId,
            Quantity = variant.Quantity
        });
        var variants = new VariantsForPrintPrices
        {
            Currency = currency,
            Variants = variant
        };
        
        try
        {
            _designPrintPriceForVariants = _printPriceService.CalculatePrintPrice(_designId, variants, UserId);
        }
        catch(InvalidServiceResponseException ex)
        {
            _responseException = ex;
        }
    }

    private void PrintPriceIsValid(Currency currency)
    {
        Assert.IsNotNull(_designPrintPrice);
        Assert.That(_designPrintPrice.Total, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.TotalCostPrice, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.SetupCharge, Is.GreaterThanOrEqualTo(0));
        Assert.That(_designPrintPrice.CostSetupCharge, Is.GreaterThanOrEqualTo(0));
        Assert.That(_designPrintPrice.ProductsPrintPrice, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.ProductsCostPrintPrice, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.UnitSetupCharge, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.UnitCostSetupCharge, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.UnitPrintPrice, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.UnitCostPrintPrice, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.QuantityOfSetups, Is.GreaterThan(0));
        Assert.That(_designPrintPrice.Currency, Is.EqualTo(currency));
        Assert.That(_designPrintPrice.QuantityOfProducts, Is.EqualTo(PositiveQuantityOfProducts));
        Assert.That(_designPrintPrice.DesignId, Is.EqualTo(_designId));
        Assert.That(_designPrintPrice.LeadTime, Is.GreaterThan(0));
        AssertDecorationPrintPrices(currency);
    }

    private void AssertDecorationPrintPrices(Currency currency)
    {
        Assert.IsNotNull(_designPrintPrice.DecorationPrintPrices);
        Assert.That(_designPrintPrice.DecorationPrintPrices!.Count, Is.GreaterThan(0));
        foreach (var printPrice in _designPrintPrice.DecorationPrintPrices)
        {
            Assert.That(printPrice.Total, Is.GreaterThan(0));
            Assert.That(printPrice.TotalCostPrice, Is.GreaterThan(0));
            Assert.That(printPrice.ProductsPrintPrice, Is.GreaterThan(0));
            Assert.That(printPrice.ProductsCostPrintPrice, Is.GreaterThan(0));
            Assert.That(printPrice.UnitPrintPrice, Is.GreaterThan(0));
            Assert.That(printPrice.UnitCostPrintPrice, Is.GreaterThan(0));
            Assert.That(printPrice.QuantityOfSetups, Is.GreaterThan(0));
            Assert.That(printPrice.Currency, Is.EqualTo(currency));
            Assert.That(printPrice.SetupCharge, Is.GreaterThan(0));
            Assert.That(printPrice.CostSetupCharge, Is.GreaterThan(0));
            Assert.That(printPrice.QuantityOfProducts, Is.EqualTo(PositiveQuantityOfProducts));
            Assert.That(printPrice.UnitSetupCharge, Is.GreaterThan(0));
            Assert.That(printPrice.UnitCostSetupCharge, Is.GreaterThan(0));
            Assert.That(printPrice.PrintAreaId, Is.Not.Empty);
            Assert.That(printPrice.PrintTechniqueId, Is.Not.Empty);
        }
    }

    private void PrintPriceForVariantsIsValid(Currency currency)
    {
        Assert.IsNotNull(_designPrintPriceForVariants);
        Assert.That(_designPrintPriceForVariants.TotalSalesPrice,
            Is.GreaterThan(0));
        Assert.That(_designPrintPriceForVariants.Currency,
            Is.EqualTo(currency));
        Assert.That(_designPrintPriceForVariants.Variants?.Count(),
            Is.EqualTo(1));
        Assert.That(_designPrintPriceForVariants.TotalSalesPrice,
            Is.GreaterThan(0));
        Assert.That(_designPrintPriceForVariants.Variants.FirstOrDefault().TotalSalesPrice,
            Is.GreaterThan(0));
        Assert.That(_designPrintPriceForVariants.Currency,
            Is.EqualTo(currency));
        Assert.That(_designPrintPriceForVariants.SalesSetupCharge,
            Is.GreaterThanOrEqualTo(0));
        Assert.That(_designPrintPriceForVariants.SalesSetupCharge, Is.GreaterThan(0));
        Assert.That(_designPrintPriceForVariants.ProductsSalesPrintPrice, Is.GreaterThan(0));
    }

    public void ErrorCodeInsteadOfPrintPriceIsReturned()
    {
        Assert.AreEqual("Invalid service response. Expected code OK, retrieved BadRequest",
            _responseException?.Message);
    }

    private string CreateDesign()
    {
        return _designService.CreateDesign(_design, UserId);
    }

    private static MemoryStream ReadImage()
    {
        return new MemoryStream(System.IO.File.ReadAllBytes(
            Path.Combine(Path.GetFullPath(AppContext.BaseDirectory), Resource, ImageName)));
    }

    private Design.Model.Design PrepareDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo()
    {
        var product = FetchProduct(SupplierItemIdWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo);
        var printArea = GetPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo(product) ?? new PrintArea();
        Assert.NotNull(printArea);

        return PrepareDesignModel(product, new[] { printArea }!,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo);
    }

    private Design.Model.Design PrepareDesignModelWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors()
    {
        var product = FetchProduct(SupplierItemIdWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors);
        var printArea = GetPrintAreaWhosePrintPriceDependOnTheNumberOfColors(product);
        Assert.NotNull(printArea);

        return PrepareDesignModel(product, new[] { printArea }!,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors);
    }

    private Design.Model.Design PrepareDesignModelWithPrintAreaWhosePrintPriceIsFixed()
    {
        var product = FetchProduct(SupplierItemIdWithPrintAreaWhosePrintPriceIsFixed);
        var printArea = GetPrintAreaWhenPrintPriceIsFixedFromProduct(product);
        Assert.NotNull(printArea);

        return PrepareDesignModel(product, new[] { printArea }!,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceIsFixed);
    }

    private Design.Model.Design PrepareEmptyDesign()
    {
        return PrepareEmptyDesignModel(SupplierItemIdWithLeadTimeConfiguration);
    }

    private Design.Model.Design PrepareCreateAnDesignWithOnePrintAreaAndOnePrintTechnique()
    {
        var product = FetchProduct(SupplierItemIdWithLeadTimeConfiguration);
        var printArea = GetPrintAreaWithLeadTimeConfiguration(product);
        Assert.NotNull(printArea);

        return PrepareDesignModel(product, new[] { printArea }!,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo);
    }

    private Design.Model.Design PrepareCreateAnDesignWithManyPrintAreasAndOnePrintTechnique()
    {
        var product = FetchProduct(SupplierItemIdWithLeadTimeConfiguration);
        var printAreas = GetPrintAreasWithLeadTimeConfiguration(product);
        Assert.NotNull(printAreas);

        return PrepareDesignModel(product, printAreas,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo);
    }

    private Design.Model.Design PrepareCreateAnDesignWithManyPrintAreasAndManyPrintTechniques()
    {
        var product = FetchProduct(SupplierItemIdWithLeadTimeConfiguration);
        var printAreas = GetPrintAreasAndPrintTechniquesWithLeadTimeConfiguration(product);
        Assert.NotNull(printAreas);

        return PrepareDesignModel(product, printAreas,
            _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo);
    }

    private Design.Model.Design PrepareDesignModel(Product.Model.Product product, IEnumerable<PrintArea> printArea,
        IEnumerable<string>? variantsSupplierItemIds = null)
    {
        var decorations = printArea!.ToList().Select(p => new Decoration
        {
            PrintAreaId = p?.ReferenceId ?? "",
            PrintTechniqueId = p?.PrintTechniques?.FirstOrDefault()?.MethodCode ?? "",
            Layers = new List<Layer>
            {
                new()
                {
                    ComponentType = ComponentType.Image,
                    ComponentId = _imageId,
                    Coordinates = new Coordinates
                    {
                        TopLeftX = (int)(p!.CoordinateTopLeftX + 1),
                        TopLeftY = (int)(p.CoordinateTopLeftY + 1),
                        TopRightX = (int)(p.CoordinateTopRightX - 1),
                        TopRightY = (int)(p.CoordinateTopRightY + 1),
                        BottomLeftX = (int)(p.CoordinateBottomLeftX + 1),
                        BottomLeftY = (int)(p.CoordinateBottomLeftY - 1),
                        BottomRightX = (int)(p.CoordinateBottomRightX - 1),
                        BottomRightY = (int)(p.CoordinateBottomRightY - 1)
                    }
                }
            }
        });
        var design = new Design.Model.Design
        {
            SupplierItemId = product.SupplierItemId ?? "",
            Decorations = decorations
        };

        if (variantsSupplierItemIds != null)
        {
            design.Variants = variantsSupplierItemIds.Select(supplierItemId => new Variant
            {
                SupplierItemId = supplierItemId,
                Quantity = PositiveQuantityOfProducts
            });
        }

        return design;
    }

    private Design.Model.Design PrepareEmptyDesignModel(string supplierItemId)
    {
        return new Design.Model.Design
        {
            SupplierItemId = supplierItemId,
            Decorations = new List<Decoration>(),
            Variants = _variantSupplierItemIdsWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo
                .Select(supplierItemId => new Variant
                {
                    SupplierItemId = supplierItemId,
                    Quantity = 0
                })
        };
    }

    private Product.Model.Product FetchProduct(string supplierItemId)
    {
        return _productService.GetProduct(supplierItemId, "SEK").Result;
    }

    private static PrintArea? GetPrintAreaWhosePrintPriceDependOnTheNumberOfColors(Product.Model.Product product)
    {
        return GetPrintAreaWithPrintTechniqueWithPrintCode(product,
            PrintCodeOfPrintTechniqueWithPrintPriceDependOnTheNumberOfColors);
    }

    private static PrintArea? GetPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo(Product.Model.Product product)
    {
        return GetPrintAreaWithPrintTechniqueWithPrintCode(product,
            PrintCodeOfPrintTechniqueWithPrintPriceDependOnTheSizeOfTheLogo);
    }

    private static PrintArea? GetPrintAreaWithLeadTimeConfiguration(Product.Model.Product product)
    {
        return GetPrintAreaWithPrintTechniqueWithPrintCode(product, PrintCodeOfPrintTechniqueWithLeadTimeConfiguration);
    }

    private static IEnumerable<PrintArea> GetPrintAreasWithLeadTimeConfiguration(Product.Model.Product product)
    {
        var printAreas = (product.PrintAreas ?? new List<PrintArea>())
            .Where(p => (p.PrintTechniques ?? new List<PrintTechnique>())
                .Any(t => t.PrintCode != null &&
                          t.PrintCode.Contains(PrintCodeOfPrintTechniqueWithLeadTimeConfiguration)))
            .ToList();
        Assert.That(printAreas.Count, Is.GreaterThan(1));
        return printAreas.GetRange(0, 2);
    }

    private static IEnumerable<PrintArea> GetPrintAreasAndPrintTechniquesWithLeadTimeConfiguration(
        Product.Model.Product product)
    {
        var printAreas1 = (product.PrintAreas ?? new List<PrintArea>())
            .FirstOrDefault(p => (p.PrintTechniques ?? new List<PrintTechnique>())
                .Any(t => t.PrintCode != null &&
                          t.PrintCode.Contains(PrintCodeOfPrintTechniqueWithLeadTimeConfiguration)));
        var printAreas2 = (product.PrintAreas ?? new List<PrintArea>())
            .FirstOrDefault(p => (p.PrintTechniques ?? new List<PrintTechnique>())
                .Any(t => t.PrintCode != null &&
                          t.PrintCode.Contains(AdditionalPrintCodeOfPrintTechniqueWithLeadTimeConfiguration)));
        Assert.NotNull(printAreas1);
        Assert.NotNull(printAreas2);
        return new[] { printAreas1, printAreas2 }!;
    }

    private static PrintArea? GetPrintAreaWithPrintTechniqueWithPrintCode(Product.Model.Product product,
        string printCode)
    {
        return (product.PrintAreas ?? new List<PrintArea>())
            .FirstOrDefault(p => (p.PrintTechniques ?? new List<PrintTechnique>())
                .Any(t => t.PrintCode != null && t.PrintCode.Contains(printCode)));
    }

    private static PrintArea? GetPrintAreaWhenPrintPriceIsFixedFromProduct(Product.Model.Product product)
    {
        return GetPrintAreaWithPrintTechniqueWithPrintCode(product, PrintCodeOfPrintTechniqueWithFixedPrintPrice);
    }

    public void CalculatePrintPriceForVariantsInSek()
    {
        CalculatePrintPriceForVariants(Currency.SEK.ToString());
    }

    public void CalculatePrintPriceInSekForVariants()
    {
        CalculatePrintPriceForVariants(Currency.SEK.ToString());
    }

    public void CalculatePrintPriceInWrongCurrencyForVariants()
    {
        CalculatePrintPriceForVariants(WrongCurrency);
    }

    public void CalculatePrintPriceInEurForVariants()
    {
        CalculatePrintPriceForVariants(Currency.EUR.ToString());
    }

    public void CalculatePrintPriceForZeroProductQuantityOfVariants()
    {
        var variant = _design.Variants ?? new List<Variant>();
        var variantsWithNegativeQuantityOfVariants = variant.Select(variant => new VariantForPrintPrices
        {
            SupplierItemId = variant.SupplierItemId,
            Quantity = ZeroQuantityOfProducts
        });
        var variants = new VariantsForPrintPrices
        {
            Currency = Currency.SEK.ToString(),
            Variants = variantsWithNegativeQuantityOfVariants
        };

        _designPrintPriceForVariants = _printPriceService.CalculatePrintPrice(
            _designId, variants, UserId);
    }

    public void CalculatePrintPriceForNegativeProductQuantityOfVariants()
    {
        var variant = _design.Variants ?? new List<Variant>();
        var variantsWithNegativeQuantityOfVariants = variant.Select(variant => new VariantForPrintPrices
        {
            SupplierItemId = variant.SupplierItemId,
            Quantity = NegativeQuantityOfProducts
        });
        var variants = new VariantsForPrintPrices
        {
            Currency = Currency.SEK.ToString(),
            Variants = variantsWithNegativeQuantityOfVariants
        };

        _designPrintPriceForVariants = _printPriceService.CalculatePrintPrice(
            _designId, variants, UserId);
    }

    public void CalculatePrintPriceWithoutVariants()
    {
        _designPrintPriceForVariants = _printPriceService.CalculatePrintPrice(
            _designId, null, UserId);
    }

    public void CalculateLeadTimeForDesign()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesBelowPreferentialThreshold.ForEach(CalculateLeadTime);
        ProductQuantitiesAbovePreferentialThreshold.ForEach(CalculateLeadTime);
    }

    public void CalculateLeadTimeForVariants()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesBelowPreferentialThreshold.ForEach(CalculateLeadTimeForVariants);
        ProductQuantitiesAbovePreferentialThreshold.ForEach(CalculateLeadTimeForVariants);
    }

    public void CalculateLeadTimeForDesignAndQuantityBelowPreferentialThreshold()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesBelowPreferentialThreshold.ForEach(CalculateLeadTime);
    }

    public void CalculateLeadTimeForVariantsAndQuantityBelowPreferentialThreshold()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesBelowPreferentialThreshold.ForEach(CalculateLeadTimeForVariants);
    }

    public void CalculateLeadTimeForDesignAndQuantityAbovePreferentialThreshold()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesAbovePreferentialThreshold.ForEach(CalculateLeadTime);
    }

    public void CalculateLeadTimeForVariantsAndQuantityAbovePreferentialThreshold()
    {
        _leadTimeForQuantity.Clear();
        ProductQuantitiesAbovePreferentialThreshold.ForEach(CalculateLeadTimeForVariants);
    }

    private void CalculateLeadTime(int quantityOfProducts)
    {
        var calculatePrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, quantityOfProducts, Currency.SEK.ToString(), UserId);
        _leadTimeForQuantity[quantityOfProducts] = calculatePrintPrice.LeadTime ?? 0;
    }

    private void CalculateLeadTimeForVariants(int quantityOfProducts)
    {
        var variant = _design.Variants.Select(variant => new VariantForPrintPrices
        {
            SupplierItemId = variant.SupplierItemId,
            Quantity = quantityOfProducts
        });
        var variants = new VariantsForPrintPrices
        {
            Variants = variant,
            Currency = Currency.SEK.ToString()
        };
        var calculatePrintPrice =
            _printPriceService.CalculatePrintPrice(_designId, variants, UserId);
        _leadTimeForQuantity[quantityOfProducts] = calculatePrintPrice.LeadTime;
    }
}