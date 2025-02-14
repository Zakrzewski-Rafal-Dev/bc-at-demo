using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.GetDesignTemplateFeature;

[Binding]
[Scope(Feature = "Get design template")]
public class GetDesignTemplateStepDefinitions
{
    private readonly GetDesignTemplateSteps _designTemplateSteps;

    public GetDesignTemplateStepDefinitions()
    {
        _designTemplateSteps = new GetDesignTemplateSteps(
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new DesignTemplateRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver())
        );
    }

    [Given(@"I have created a new design template with name for user id")]
    public void GivenIHaveCreatedANewDesignTemplateWithNameForUserId()
    {
        _designTemplateSteps.CreateDesignTemplateWithUniqueName();
    }

    [When(@"I request for design template for user id")]
    public void WhenIRequestForDesignTemplateForUserId()
    {
        _designTemplateSteps.GetDesignTemplate();
    }

    [When(@"I request for design template for other user id")]
    public void WhenIRequestForDesignTemplateForOtherUserId()
    {
        _designTemplateSteps.GetDesignTemplateForOtherUserId();
    }

    [When(@"I request for design template for user id and locale (.*)")]
    public void WhenIRequestForDesignTemplateForOtherUserIdAndLocale(string locale)
    {
        _designTemplateSteps.GetDesignTemplateForOtherUserIdAndLocale(locale);
    }

    [Then(@"The design template is provided with name and default language")]
    public void ThenTheDesignTemplateIsProvidedWithNameAndDefaultLanguage()
    {
        _designTemplateSteps.DesignTemplateWithNameAndDefaultLanguageIsProvided();
    }

    [Then(@"The design template is not provided")]
    public void ThenTheDesignTempleIsNotProvided()
    {
        _designTemplateSteps.DesignTemplateIsNotProvided();
    }

    [Then(@"The design template is provided with name and translated to locale (.*)")]
    public void ThenTheDesignTemplateIsProvidedWithNameAndTranslated(string locale)
    {
        _designTemplateSteps.DesignTemplateWithNameIsProvidedAndTranslated(locale);
    }
}