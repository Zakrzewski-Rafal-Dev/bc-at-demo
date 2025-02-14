namespace BrandingConfigurator.AcceptanceTests.Business.Cms.Model;

public class CmsItem
{
    public CmsItemId? ItemId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<CmsItemComponent>? Components { get; set; }
}