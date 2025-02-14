using System.Net;
using System.Net.Http.Json;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.Design.Service;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Model;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;

public class DesignRestApiService : RestService, IDesignService
{
    private const string EndpointName = "/design";

    public DesignRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public string CreateDesign(Model.Design design, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallCreateMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl().ToString()), JsonContent.Create(design), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.Created)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.Created, responseMessage.StatusCode);
        }
        
        return JsonConvert.DeserializeObject<DesignId>(responseMessage.Content.ReadAsStringAsync().Result).Id;
    }

    public string CreateDesignTemplate(string designId, string? name, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallCreateMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{designId}/template?name={name}"), null, userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.Created)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.Created, responseMessage.StatusCode);
        }

        return JsonConvert.DeserializeObject<DesignTemplateId>(responseMessage.Content.ReadAsStringAsync().Result).Id; 
    }

    public Model.Design GetDesign(string designId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{designId}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public void UpdateDesign(Model.Design design, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallUpdateMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{design.Id}"), JsonContent.Create(design), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.NoContent, responseMessage.StatusCode);
        }
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }

    private async Task<Model.Design> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<Model.Design>(await responseMessage.Content.ReadAsStringAsync());
    }
}