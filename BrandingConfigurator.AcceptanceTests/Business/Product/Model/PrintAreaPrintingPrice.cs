using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Product.Model;

public class PrintAreaPrintingPrice
{
    public decimal? Price { get; set; }
    public decimal? Quantity { get; set; }
    public string? DependentValue { get; set; }
    public string? DependentOn { get; set; }
    public string? DependentUnit { get; set; }
    public string? PrintTechniqueId { get; set; }
    public Currency? Currency { get; set; }
}