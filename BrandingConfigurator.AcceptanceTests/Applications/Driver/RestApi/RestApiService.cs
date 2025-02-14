using BrandingConfigurator.AcceptanceTests.Applications.Configuration;

namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi
{
    public abstract class RestService
    {
        private readonly TestRunConfiguration _configuration;
        private readonly IRestDriver _restDriver;

        protected RestService(TestRunConfiguration configuration, IRestDriver restDriver)
        {
            _configuration = configuration;
            _restDriver = restDriver;
        }

        protected Uri GetEndpointServiceUrl()
        {
            return new Uri(GetApiUrl() + GetServiceRelatedUrl());
        }

        protected abstract string GetServiceRelatedUrl();

        protected IRestDriver GetRestDriver()
        {
            return _restDriver;
        }
        
        public string GetApiUrl()
        {
            return _configuration.Url;
        }
    }
}
