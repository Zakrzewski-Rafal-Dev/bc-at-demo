namespace BrandingConfigurator.AcceptanceTests.Business.Product.Model;

public class Product
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string? SupplierItemId { get; set; }
    public string? ModelCode { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }
    public IEnumerable<PrintArea>? PrintAreas { get; set; }
}
