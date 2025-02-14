namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi
{
    public class RestDriver : IRestDriver
    {
        private const string HeaderParameterKey = "X-Context";
        private const string HeaderUserIdKey = "X-User-ID";
        private const string HeaderApiVersionKey = "X-api-version";
        private const string HeaderParameterValue = "AcceptanceTests";

        public async Task<HttpResponseMessage> CallGetMethodOnEndpointAsync(Uri endpointUri, string? userId = null, string? apiVersion = null)
        {
            return await GetResponseObjectAsync(endpointUri, HttpMethod.Get, userId, apiVersion);
        }

        public async Task<HttpResponseMessage> CallCreateMethodOnEndpointAsync(
            Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpointUri);
            request.Content = content;
            using var client = CreateHttpClient(userId, apiVersion);

            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> CallUpdateMethodOnEndpointAsync(
            Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, endpointUri);
            request.Content = content;
            using var client = CreateHttpClient(userId, apiVersion);

            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> CallEditImageMethodOnEndpointAsync(
            Uri endpointUri, HttpContent content, string? userId = null, string? apiVersion = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpointUri);
            request.Content = content;
            using var client = CreateHttpClient(userId, apiVersion);

            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> CallDeleteMethodOnEndpointAsync(
            Uri endpointUri, string? userId = null, string? apiVersion = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, endpointUri);
            using var client = CreateHttpClient(userId, apiVersion);

            return await client.SendAsync(request);
        }

        private async Task<HttpResponseMessage> GetResponseObjectAsync(
            Uri endpointUri, HttpMethod httpMethod, string? userId, string? apiVersion)
        {
            var request = new HttpRequestMessage(httpMethod, endpointUri);
            using var client = CreateHttpClient(userId, apiVersion);

            return await client.SendAsync(request);
        }

        private static HttpClient CreateHttpClient(string? userId, string? apiVersion)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            var httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add(HeaderParameterKey, HeaderParameterValue);
            
            if (apiVersion != null)
            {
                httpClient.DefaultRequestHeaders.Add(HeaderApiVersionKey, apiVersion);
            }
            
            if (userId != null)
            {
                httpClient.DefaultRequestHeaders.Add(HeaderUserIdKey, userId);
            }

            return httpClient;
        }
    }
}