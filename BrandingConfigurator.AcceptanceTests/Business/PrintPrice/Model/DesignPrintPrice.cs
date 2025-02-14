namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

public class DesignPrintPrice
{
    public decimal? Total { get; set; }
    public decimal? TotalCostPrice { get; set; }
    public decimal? SetupCharge { get; set; }
    public decimal? CostSetupCharge { get; set; }
    public decimal? ProductsPrintPrice { get; set; }
    public decimal? ProductsCostPrintPrice { get; set; }
    public decimal? UnitSetupCharge { get; set; }
    public decimal? UnitCostSetupCharge { get; set; }
    public decimal? UnitPrintPrice { get; set; }
    public decimal? UnitCostPrintPrice { get; set; }
    public int? QuantityOfSetups { get; set; }
    public Currency? Currency { get; set; }
    public int? QuantityOfProducts { get; set; }
    public string? DesignId { get; set; }
    public int? LeadTime { get; set; }
    public IEnumerable<DecorationPrintPrice>? DecorationPrintPrices { get; set; }
}