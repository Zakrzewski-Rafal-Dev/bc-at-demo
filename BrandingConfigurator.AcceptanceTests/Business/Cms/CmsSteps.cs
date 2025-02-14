using BrandingConfigurator.AcceptanceTests.Business.Cms.Model;
using BrandingConfigurator.AcceptanceTests.Business.Cms.Service;
using BrandingConfigurator.AcceptanceTests.Business.Common.Model;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Cms;

public class CmsSteps
{
    private readonly ICmsService _cmsService;
    private CmsContent _cmsContent;

    public CmsSteps(ICmsService cmsService)
    {
        _cmsService = cmsService;
    }

    public void GetFaqForHelpCenterWithSwedishLocale()
    {
        _cmsContent = _cmsService.GetCmsContent(CmsContentId.helpcenter, CmsItemId.faq, Locale.sv_SE);
    }

    public void GetFaqForHelpCenterWithEnglishLocale()
    {
        _cmsContent = _cmsService.GetCmsContent(CmsContentId.helpcenter, CmsItemId.faq, Locale.en_GB);
    }

    public void SwedishFaqForHelpCenterIsProvided()
    {
        TranslatedCmsContentIsProvided(CmsContentId.helpcenter, CmsItemId.faq, Locale.sv_SE);
    }
    
    public void EnglishFaqForHelpCenterIsProvided()
    {
        TranslatedCmsContentIsProvided(CmsContentId.helpcenter, CmsItemId.faq, Locale.en_GB);
    }
    
    private void TranslatedCmsContentIsProvided(CmsContentId cmsContentId, CmsItemId cmsItemId, Locale locale)
    {
        Assert.IsNotNull(_cmsContent);
        Assert.That(_cmsContent.Locale, Is.EqualTo(locale.ToString()));
        Assert.That(_cmsContent.ContentId, Is.EqualTo(cmsContentId));
        Assert.IsNotNull(_cmsContent.Item);
        Assert.That(_cmsContent.Item?.ItemId, Is.EqualTo(cmsItemId));
        Assert.That(_cmsContent.Item?.Description, Is.EqualTo("Frequently Asked Question"));
        Assert.That(_cmsContent.Item?.Title, Is.EqualTo("FAQ"));
        Assert.IsNotNull(_cmsContent.Item?.Components);
        Assert.That(_cmsContent.Item?.Components?.Count(), Is.GreaterThan(0));
        var cmsItemComponent = _cmsContent.Item?.Components?.FirstOrDefault();
        Assert.IsNotNull(cmsItemComponent);
        Assert.That(cmsItemComponent?.Title, Is.Not.Empty);
        Assert.That(cmsItemComponent?.Subtitle, Is.EqualTo(""));
        Assert.That(cmsItemComponent?.YouTubeId, Is.EqualTo(""));
        Assert.That(cmsItemComponent?.Content, Is.Not.Empty);
    }
}