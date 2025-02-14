using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.PrintProof.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintProof.Service;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintProof.RestApi;

public class PrintProofRestApiService : RestService, IPrintProofService
{
    private const string EndpointName = "/design";

    public PrintProofRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public DesignPrintProof GetPrintProof(string designId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{designId}/printproof")).Result;

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

    private static async Task<DesignPrintProof> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<DesignPrintProof>(await responseMessage.Content.ReadAsStringAsync());
    }
}