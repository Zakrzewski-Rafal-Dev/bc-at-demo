namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;

public interface IRestDriver
{
    Task<HttpResponseMessage> CallGetMethodOnEndpointAsync(Uri endpointUri, string? userId = null, string? apiVersion = null);
    Task<HttpResponseMessage> CallCreateMethodOnEndpointAsync(Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null);
    Task<HttpResponseMessage> CallUpdateMethodOnEndpointAsync(Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null);
    Task<HttpResponseMessage> CallEditImageMethodOnEndpointAsync(Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null);
    Task<HttpResponseMessage> CallDeleteMethodOnEndpointAsync(Uri endpointUri, string? userId = null, string? apiVersion = null);
}
