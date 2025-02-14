namespace BrandingConfigurator.AcceptanceTests.Business.Price.Model;

public class PrintPricesLadder
{
    public int Quantity { get; set; }
    public string? PricesDependentOn { get; set; }
    public string? Unit { get; set; }
    public string? Currency { get; set; }
    public IEnumerable<PrintPrice>? PrintPrices { get; set; }
}
