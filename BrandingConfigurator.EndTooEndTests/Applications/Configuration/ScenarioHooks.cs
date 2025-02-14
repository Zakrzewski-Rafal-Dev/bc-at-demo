using BoDi;
using BrandingConfigurator.EndTooEndTests.Applications.Driver.Web;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BrandingConfigurator.EndTooEndTests.Applications.Configuration;

[Binding]
public class ScenarioHooks
{
    private readonly IObjectContainer objectContainer;

    public ScenarioHooks(IObjectContainer objectContainer)
    {
        this.objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void Setup()
    {
        objectContainer.RegisterInstanceAs(new ChromeBrowser(TestRunConfiguration.GetInstance()).GetWebDriver());
    }

    [AfterScenario]
    public void CleanUp(IWebDriver webDriver)
    {
        webDriver.Close();
        webDriver.Quit();
    }
}
