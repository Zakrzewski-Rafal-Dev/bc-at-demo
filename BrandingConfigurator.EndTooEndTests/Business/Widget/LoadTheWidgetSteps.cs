using OpenQA.Selenium;
using NUnit.Framework;
using BrandingConfigurator.EndTooEndTests.Applications.Configuration;

namespace BrandingConfigurator.EndTooEndTests.Business.Widget;

public class LoadTheWidgetSteps
{
    private IWebDriver _webDriver;
    public LoadTheWidgetSteps(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void IWantToLoadTheWidget()
    {
        _webDriver.Navigate().GoToUrl(TestRunConfiguration.GetInstance().WidgetUrl);
        _webDriver.FindElement(By.Id("trigger")).Click();
    }

    public void WidgetIsLoaded()
    {
        var modalContent = _webDriver.FindElement(By.ClassName("bc-modal-content"));
        Assert.That(modalContent.Displayed, Is.True);
    }
}
