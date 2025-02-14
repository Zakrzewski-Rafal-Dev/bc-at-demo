namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

public class VariantPrintPrice
{
    public int Index { get; set; }
    public string? SupplierItemId { get; set; }
    public decimal? TotalSalesPrice { get; set; }
    public decimal? TotalCostPrice { get; set; }
    public int? Quantity { get; set; }
    public int? LeadTime { get; set; }
}
