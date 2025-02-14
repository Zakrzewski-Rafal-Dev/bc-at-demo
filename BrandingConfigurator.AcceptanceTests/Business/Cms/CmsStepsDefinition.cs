using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Cms.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Common.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Cms;

[Binding]
public class CmsStepsDefinition
{
    private readonly CmsSteps _cmsSteps;

    public CmsStepsDefinition()
    {
        _cmsSteps = new CmsSteps(new CmsRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [When(@"I request for FAQ for Help Center with Swedish locale")]
    public void WhenIRequestForFaqForHelpCenterWithSwedishLocale()
    {
        _cmsSteps.GetFaqForHelpCenterWithSwedishLocale();
    }
    
    [When(@"I request for FAQ for Help Center with English locale")]
    public void WhenIRequestForFaqForHelpCenterWithEnglishLocale()
    {
        _cmsSteps.GetFaqForHelpCenterWithEnglishLocale();
    }
    
    [Then(@"FAQ for Help Center is provided and translated to Swedish locale")]
    public void ThenFaqForHelpCenterIsProvidedAndTranslatedToSwedishLocale()
    {
        _cmsSteps.SwedishFaqForHelpCenterIsProvided();
    }
    
    [Then(@"FAQ for Help Center is provided and translated to English locale")]
    public void ThenFaqForHelpCenterIsProvidedAndTranslatedToEnglishLocale()
    {
        _cmsSteps.EnglishFaqForHelpCenterIsProvided();
    }
}