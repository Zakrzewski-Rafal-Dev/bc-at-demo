using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Service;

public interface IPrintPriceService
{
    public DesignPrintPrice CalculatePrintPrice(
        string designId, int? quantityOfProducts, string priceCurrency, string userId);
    public DesignPrintPriceForVariants CalculatePrintPrice(
        string designId, VariantsForPrintPrices? variant, string userId);
}