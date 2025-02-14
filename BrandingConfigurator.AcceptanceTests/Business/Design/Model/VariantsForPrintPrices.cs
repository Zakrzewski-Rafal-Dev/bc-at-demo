using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Model;

public class VariantsForPrintPrices
{
    public string Currency { get; set; }
    public IEnumerable<VariantForPrintPrices>? Variants { get; set; }
}