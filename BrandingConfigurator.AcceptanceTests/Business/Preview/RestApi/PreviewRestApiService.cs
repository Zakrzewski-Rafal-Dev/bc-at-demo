using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Preview.Model;
using BrandingConfigurator.AcceptanceTests.Business.Preview.Service;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Preview.RestApi;

public class PreviewRestApiService : RestService, IPreviewService
{
    private const string EndpointName = "/design";

    public PreviewRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public DesignPreview GetPreview(string designId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{designId}/preview"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    private static async Task<DesignPreview> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<DesignPreview>(await responseMessage.Content.ReadAsStringAsync());
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }
}