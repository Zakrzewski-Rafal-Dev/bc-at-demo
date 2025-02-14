using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Time.Service.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Time
{
    [Binding]
    public class TimeStepDefinitions
    {
        private readonly TimeSteps _timeSteps;

        public TimeStepDefinitions()
        {
            _timeSteps = new TimeSteps(new TimeRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
        }

        [When("I requests for server time")]
        public void IRequestsForServerTime()
        {
            _timeSteps.FetchServerTime();
        }

        [Then("server time is provided")]
        public void ServerTimeIsProvided()
        {
            _timeSteps.ServerTimeIsProvided();
        }
    }
}