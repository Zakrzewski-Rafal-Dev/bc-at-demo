using Microsoft.Extensions.Configuration;

namespace BrandingConfigurator.AcceptanceTests.Applications.Configuration
{
    public class TestRunConfiguration
    {
        public string Url { get; set; }

        public static TestRunConfiguration GetInstance()
        {
            var applicationSettings = new TestRunConfiguration();
            GetIConfigurationRoot().Bind(applicationSettings);
        
            return applicationSettings;
        }
        
        private static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("AcceptanceTestSettings.json", optional: true)
                .Build();
        }
    }
}