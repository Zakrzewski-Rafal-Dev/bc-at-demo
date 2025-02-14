using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;

public class DesignTemplateRestApiService : RestService, IDesignTemplateService
{
    private const string EndpointName = "/design/template";

    public DesignTemplateRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public Model.DesignTemplate GetDesignTemplate(string designTemplateId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{designTemplateId}"),
                userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public Model.DesignTemplate GetDesignTemplate(string designTemplateId, string userId, string locale)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{designTemplateId}?locale={locale}"),
                userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public Model.DesignTemplate GetDesignTemplateByNameAndSupplierItemId(string name, string supplierItemId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{name}/product/{supplierItemId}"),
                userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public Model.DesignTemplate GetDesignTemplateByNameAndSupplierItemId(string name, string supplierItemId, string userId,string locale)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{name}/product/{supplierItemId}?locale={locale}"),
                userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public IEnumerable<Model.DesignTemplate> GetDesignTemplates(string userId, Paging paging, string name = null)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"?pageNumber={paging?.PageNumber}&pageSize={paging?.PageSize}" + (name != null ? $"&query={name}" : "")), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentsAsync(responseMessage).Result;
    }

    public IEnumerable<Model.DesignTemplate> GetDesignTemplates(string userId, Paging paging, string locale, string name = null)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() +
                $"?pageNumber={paging?.PageNumber}&pageSize={paging?.PageSize}" + (name != null ? $"&query={name}" : "") + $"&locale={locale}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentsAsync(responseMessage).Result;
    }

    public void DeleteDesignTemplate(string designTemplateId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallDeleteMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/{designTemplateId}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.NoContent)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.NoContent, responseMessage.StatusCode);
        }
    }

    public void UpdateDesignTemplate(string designId, string designTemplateId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallUpdateMethodOnEndpointAsync(
                new Uri(GetApiUrl() + $"/design/{designId}/template/{designTemplateId}"), null, userId)
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

    private static async Task<Model.DesignTemplate> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<Model.DesignTemplate>(
            await responseMessage.Content.ReadAsStringAsync());
    }

    private static async Task<IEnumerable<Model.DesignTemplate>> ReadResponseContentsAsync(
        HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<IEnumerable<Model.DesignTemplate>>(
            await responseMessage.Content.ReadAsStringAsync());
    }
}