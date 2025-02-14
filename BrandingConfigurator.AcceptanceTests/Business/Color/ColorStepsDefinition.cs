using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Color.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Color.Service;

namespace BrandingConfigurator.AcceptanceTests.Business.Color;

[Binding]
public class ColorStepsDefinition
{
    private readonly ColorSteps _colorSteps;

    public ColorStepsDefinition()
    {
        _colorSteps = new ColorSteps(new ColorRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [When(@"I ask for paged color configuration")]
    public void WhenIRequestForPagedColorConfiguration()
    {
        _colorSteps.GetPagedColorConfiguration();
    }

    [When(@"I ask for filtered color configuration")]
    public void WhenIRequestForFilteredColorConfiguration()
    {
        _colorSteps.GetFilteredColorConfiguration();
    }

    [Then(@"Paged configuration is returned")]
    public void ThenPagedColorConfigurationIsProvided()
    {
        _colorSteps.PagedColorConfigurationIsValid();
    }

    [Then(@"Filtered page is returned")]
    public void ThenFilteredColorConfigurationIsProvided()
    {
        _colorSteps.FilteredColorConfigurationIsValid();
    }
}
