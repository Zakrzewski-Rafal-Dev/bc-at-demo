using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.GetDesignTemplatesFeature;

[Binding]
[Scope(Feature = "Get design templates")]
public class GetDesignTemplatesStepDefinitions
{
    private readonly GetDesignTemplatesSteps _designTemplateSteps;

    public GetDesignTemplatesStepDefinitions()
    {
        _designTemplateSteps = new GetDesignTemplatesSteps(
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

    [Given(@"I have created multiple design templates with name for user id")]
    public void GivenIHaveCreatedMultipleDesignTemplatesWithNameForUserId()
    {
        _designTemplateSteps.CreateTwoDesignTemplatesWithName();
    }

    [When(@"I request for design templates for user id")]
    public void WhenIRequestForDesignTemplatesForUserId()
    {
        _designTemplateSteps.GetDesignTemplates();
    }

    [When(@"I request for paged design templates for user id")]
    public void WhenIRequestForPagedDesignTemplatesForUserId()
    {
        _designTemplateSteps.GetPagedDesignTemplates();
    }

    [When(@"I request for design templates for other user id")]
    public void WhenIRequestForDesignTemplatesForOtherUserId()
    {
        _designTemplateSteps.GetDesignTemplatesForOtherUserId();
    }

    [When(@"I request for design templates by name for user id")]
    public void WhenIRequestForDesignTemplatesByNameForUserId()
    {
        _designTemplateSteps.GetDesignTemplatesByNameForUserId();
    }

    [When(@"I request for design templates by other name for user id")]
    public void WhenIRequestForDesignTemplatesByOtherNameForUserId()
    {
        _designTemplateSteps.GetDesignTemplatesByOtherNameForUserId();
    }

    [When(@"I request for design templates for user id and locale (.*)")]
    public void WhenIRequestForDesignTemplatesForUserIdAndLocale(string locale)
    {
        _designTemplateSteps.GetDesignTemplatesForUserIdAndLocale(locale);
    }

    [Then(@"The design templates are provided")]
    public void ThenTheDesignTemplatesAreProvided()
    {
        _designTemplateSteps.DesignTemplatesAreProvided();
    }

    [Then(@"Paged design templates are provided")]
    public void ThenPagedDesignTemplatesAreProvided()
    {
        _designTemplateSteps.PagedDesignTemplatesAreProvided();
    }

    [Then(@"The design templates are not provided")]
    public void ThenTheDesignTemplatesAreNotProvided()
    {
        _designTemplateSteps.DesignTemplatesAreNotProvided();
    }

    [Then(@"The design templates are provided and translated to locale (.*)")]
    public void ThenTheDesignTemplatesAreProvidedAndTranslated(string locale)
    {
        _designTemplateSteps.DesignTemplatesAreProvidedAndTranslated(locale);
    }
}