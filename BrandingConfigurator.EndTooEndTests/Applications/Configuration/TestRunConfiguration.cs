using Microsoft.Extensions.Configuration;

namespace BrandingConfigurator.EndTooEndTests.Applications.Configuration;

public class TestRunConfiguration
{
    public string? WidgetUrl { get; set; }
    public bool RunTestOnGrid { get; set; }
    public string? GridUrl { get; set; }

    public static TestRunConfiguration GetInstance()
    {
        var applicationSettings = new TestRunConfiguration();
        GetIConfigurationRoot().Bind(applicationSettings);

        return applicationSettings;
    }

    private static IConfigurationRoot GetIConfigurationRoot()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("EndToEndTestSettings.json", optional: true)
            .Build();
    }
}
