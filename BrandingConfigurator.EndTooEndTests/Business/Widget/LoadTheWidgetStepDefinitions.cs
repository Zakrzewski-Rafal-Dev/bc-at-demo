using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BrandingConfigurator.EndTooEndTests.Business.Widget;

[Binding]
public class LoadTheWidgetStepDefinitions
{
    private readonly LoadTheWidgetSteps _loadTheWidgetSteps;

    public LoadTheWidgetStepDefinitions(IWebDriver webDriver)
    {
        _loadTheWidgetSteps = new LoadTheWidgetSteps(webDriver);
    }

    [When(@"I want to load the Widget")]
    public void WhenIWantToLoadTheWidget()
    {
        _loadTheWidgetSteps.IWantToLoadTheWidget();
    }

    [Then(@"Widget is loaded")]
    public void ThenWidgetIsLoaded()
    {
        _loadTheWidgetSteps.WidgetIsLoaded();
    }
}
