using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Color.Model;
using BrandingConfigurator.AcceptanceTests.Business.Color.Service;
using Newtonsoft.Json;
using System.Net;

namespace BrandingConfigurator.AcceptanceTests.Business.Color.RestApi;

public class ColorRestApiService : RestService, IColorService
{
    private const string EndpointName = "/color";

    public ColorRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public ColorConfiguration GetColorConfiguration(int pageNumber, int pageSize, string filter)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/configuration?pageNumber={pageNumber}&pageSize={pageSize}&filterValue={filter}"))
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
    private async Task<ColorConfiguration> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<ColorConfiguration>(await responseMessage.Content.ReadAsStringAsync());
    }
}
