namespace BrandingConfigurator.AcceptanceTests.Business.Design.Model;

public class Design
{
    public string Id { get; set; }
    public string SupplierItemId { get; set; }
    public IEnumerable<Variant>? Variants { get; set; }
    public IEnumerable<Decoration> Decorations { get; set; }
}
