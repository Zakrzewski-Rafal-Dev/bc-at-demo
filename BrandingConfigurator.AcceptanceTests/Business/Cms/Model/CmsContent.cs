namespace BrandingConfigurator.AcceptanceTests.Business.Cms.Model;

public class CmsContent
{
    public CmsContentId? ContentId { get; set; }
    public string? Locale { get; set; }
    public CmsItem? Item { get; set; }
}