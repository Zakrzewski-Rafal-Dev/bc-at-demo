using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Time.Service.RestApi
{
    public class TimeRestApiService : RestService, ITimeService
    {
        private const string EndpointName = "/time";
        private readonly string[] _pathsToSchema = { "Business", "Time", "Service", "RestApi", "Schema", "GetTimeSchema.json" };

        public TimeRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
            base(configuration, restDriver)
        {
        }

        public async Task<Model.Time> GetTimeAsync()
        {
            var response = await GetRestDriver().CallGetMethodOnEndpointAsync(GetEndpointServiceUrl());
            var combinePathToSchema = Path.Combine(_pathsToSchema);
            
            ValidateResponse(response, HttpStatusCode.OK, GetEndpointSchema(combinePathToSchema));

            return await ReadResponseContentAsync(response);
        }

        protected override string GetServiceRelatedUrl()
        {
            return EndpointName;
        }

        private static void ValidateResponse(HttpResponseMessage response, HttpStatusCode statusCode, string schema)
        {
            var restApiResponseValidator = new RestApiResponseValidator(response);

            restApiResponseValidator.ValidateStatusCode(statusCode);
            restApiResponseValidator.ValidateSchema(schema);
        }

        private static string GetEndpointSchema(string pathToSchema)
        {
            return System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), pathToSchema));
        }

        private static async Task<Model.Time> ReadResponseContentAsync(HttpResponseMessage responseMessage)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Model.Time>(json);
        }
    }
}