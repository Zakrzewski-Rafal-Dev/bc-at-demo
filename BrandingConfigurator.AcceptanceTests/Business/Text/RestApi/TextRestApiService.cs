using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Text.Model;
using BrandingConfigurator.AcceptanceTests.Business.Text.Service;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.RestApi;

public class TextRestApiService : RestService, ITextService
{
    private const string EndpointName = "/text";

    public TextRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) : base(configuration,
    restDriver)
    {
    }

    public TextConfiguration GetTextConfiguration(int pageNumber, int pageSize, string? filterValue)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl() + $"/configuration?{nameof(pageNumber)}={pageNumber}&{nameof(pageSize)}={pageSize}&{nameof(filterValue)}={filterValue}")
            ).Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public TextResponse CreateText(TextFormatting textFormatting, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallCreateMethodOnEndpointAsync(
                new Uri(GetEndpointServiceUrl().ToString()), JsonContent.Create(textFormatting), userId)
            .Result;

        return new TextResponse
        {
            StatusCode = responseMessage.StatusCode,
            Content = responseMessage.StatusCode == HttpStatusCode.Created ?
                JsonConvert.DeserializeObject<TextId>(responseMessage.Content.ReadAsStringAsync().Result).Id :
                responseMessage.Content.ReadAsStringAsync().Result
        };
    }

    public Model.Text GetTextMetadata(string textId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{textId}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return JsonConvert.DeserializeObject<Model.Text>(responseMessage.Content.ReadAsStringAsync().Result);
    }

    public Stream GetTextFile(string url, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetApiUrl() + url), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return responseMessage.Content.ReadAsStream();
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }

    private static async Task<TextConfiguration> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<TextConfiguration>(await responseMessage.Content.ReadAsStringAsync());
    }
}
