using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Cms.Model;
using BrandingConfigurator.AcceptanceTests.Business.Cms.Service;
using BrandingConfigurator.AcceptanceTests.Business.Common.Model;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Cms.RestApi;

public class CmsRestApiService : RestService, ICmsService
{
    private const string EndpointName = "/cms";
    
    public CmsRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) 
        : base(configuration, restDriver)
    {
    }

    public CmsContent GetCmsContent(CmsContentId cmsContentId, CmsItemId cmsItemId, Locale locale)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/content/{cmsContentId}/item/{cmsItemId}?locale={locale}"))
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }

    private static async Task<CmsContent> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<CmsContent>(await responseMessage.Content.ReadAsStringAsync());
    }
}