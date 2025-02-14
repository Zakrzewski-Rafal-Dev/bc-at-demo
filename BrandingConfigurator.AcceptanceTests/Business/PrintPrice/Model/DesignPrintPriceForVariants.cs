namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

public class DesignPrintPriceForVariants
{
    public decimal? TotalSalesPrice { get; set; }
    public decimal? TotalCostPrice { get; set; }
    public decimal? SalesSetupCharge { get; set; }
    public decimal? CostSetupCharge { get; set; }
    public decimal? ProductsSalesPrintPrice { get; set; }
    public decimal? ProductsCostPrintPrice { get; set; }
    public Currency? Currency { get; set; }
    public string? DesignId { get; set; }
    public int LeadTime { get; set; }
    public IEnumerable<VariantPrintPrice>? Variants { get; set; }
}