using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.File.Service;

namespace BrandingConfigurator.AcceptanceTests.Business.File.RestApi;

public class FileRestApiService : RestService, IFileService
{
    private const string EndpointName = "/file";

    public FileRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) : base(configuration,
        restDriver)
    {
    }

    public Stream GetFile(string path)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetApiUrl() + path))
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
}