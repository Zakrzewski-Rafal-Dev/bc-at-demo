using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;

public class ImageRestApiService : RestService, IImageService
{
    private const string EndpointName = "/image";
    private const string InputName = "file";

    public ImageRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) : base(configuration,
        restDriver)
    {
    }

    public string UploadImage(Stream memoryStream, string fileName, string userId)
    {
        var content = GetMultipartFormDataContent(memoryStream, fileName);

        var responseMessage = GetRestDriver()
            .CallCreateMethodOnEndpointAsync(GetEndpointServiceUrl(), content, userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.Created)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.Created, responseMessage.StatusCode, responseMessage.Content.ReadAsStringAsync().Result);
        }
        
        return JsonConvert.DeserializeObject<ImageId>(responseMessage.Content.ReadAsStringAsync().Result).Id;
    }

    public Model.Image GetImageMetadata(string imageId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{imageId}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public IEnumerable<Model.Image> GetImagesMetadata(string userId, Paging? paging)
    {
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/?pageNumber={paging?.PageNumber}&pageSize={paging?.PageSize}"), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return JsonConvert.DeserializeObject<IEnumerable<Model.Image>>(responseMessage.Content.ReadAsStringAsync().Result);
    }

    public string EditImage(string imageId, string userId, ImageFormatting imageFormatting)
    {
        var responseMessage = GetRestDriver()
            .CallEditImageMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{imageId}/edit"), JsonContent.Create(imageFormatting), userId)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.Created)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.Created, responseMessage.StatusCode, responseMessage.Content.ReadAsStringAsync().Result);
        }

        return JsonConvert.DeserializeObject<ImageId>(responseMessage.Content.ReadAsStringAsync().Result).Id;
    }

    public void DeleteImage(string imageId, string userId)
    {
        var responseMessage = GetRestDriver()
            .CallDeleteMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{imageId}/delete"), userId)
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

    private static MultipartFormDataContent GetMultipartFormDataContent(Stream memoryStream, string fileName)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(memoryStream), InputName, fileName);

        return content;
    }

    private static async Task<Model.Image> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<Model.Image>(await responseMessage.Content.ReadAsStringAsync());
    }
}