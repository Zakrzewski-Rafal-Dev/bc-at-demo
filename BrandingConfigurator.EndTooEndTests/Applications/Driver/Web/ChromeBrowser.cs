using BrandingConfigurator.EndTooEndTests.Applications.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace BrandingConfigurator.EndTooEndTests.Applications.Driver.Web;

public class ChromeBrowser
{
    private IWebDriver _driver;

    public ChromeBrowser(TestRunConfiguration configuration)
    {
        if (configuration.RunTestOnGrid)
        {
            if (string.IsNullOrEmpty(configuration.GridUrl))
                throw new ArgumentException("Property of GridUrl is empty");

            _driver = new RemoteWebDriver(new Uri(configuration.GridUrl), CreateChromeOptions());
        }
        else
        {
            _driver = new ChromeDriver(CreateChromeOptions());
        }
    }

    public IWebDriver GetWebDriver()
    => _driver;

    private ChromeOptions CreateChromeOptions()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--incognito");
        chromeOptions.AddArguments("--disable-logging");
        chromeOptions.AddArguments("--disable-extensions");
        chromeOptions.AddArguments("--test-type");
        chromeOptions.AddArguments("--ignore-ssl-errors=yes");
        chromeOptions.AddArguments("--ignore-certificate-errors");
        chromeOptions.AddArguments("--disable-notifications");
        chromeOptions.AddArguments("--start-maximized");
        return chromeOptions;
    }
}
