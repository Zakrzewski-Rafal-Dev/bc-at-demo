using BrandingConfigurator.Domain.PrintPrice.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Product.Model;

public class ProductPrices
{
    public IEnumerable<PrintTechniquePrice>? PrintTechniquesPrices { get; set; }
    public IEnumerable<PrintAreaPrice>? PrintAreaPrices { get; set; }
    public IEnumerable<PrintAreaPrintingPrice>? PrintingPrices { get; set; }
}
