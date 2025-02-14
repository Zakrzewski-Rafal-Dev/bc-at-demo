using BrandingConfigurator.AcceptanceTests.Business.Cms.Model;
using BrandingConfigurator.AcceptanceTests.Business.Common.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Cms.Service;

public interface ICmsService
{
    public CmsContent GetCmsContent(CmsContentId cmsContentId, CmsItemId cmsItemId, Locale locale);
}