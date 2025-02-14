using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.File.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.DeleteDesignTemplateFeature;

[Binding]
[Scope(Feature = "Delete design template")]
public class DeleteDesignTemplateStepDefinitions
{
    private readonly DeleteDesignTemplateSteps _designTemplateSteps;

    public DeleteDesignTemplateStepDefinitions()
    {
        _designTemplateSteps = new DeleteDesignTemplateSteps(
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new DesignTemplateRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new FileRestApiService(TestRunConfiguration.GetInstance(), new RestDriver())
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

    [When(@"I delete the design template for user id")]
    public void WhenIDeleteTheDesignTemplateForUserId()
    {
        _designTemplateSteps.DeleteTheDesignTemplate();
    }

    [When(@"I delete the design template for other user id")]
    public void WhenIDeleteTheDesignTemplateForOtherUserId()
    {
        _designTemplateSteps.DeleteTheDesignTemplateForOtherUserId();
    }

    [Then(@"The design template is provided with name")]
    public void ThenTheDesignTemplateIsProvidedWithName()
    {
        _designTemplateSteps.DesignTemplateWithNameIsProvided();
    }

    [Then(@"The design template is not provided")]
    public void ThenTheDesignTempleIsNotProvided()
    {
        _designTemplateSteps.DesignTemplateIsNotProvided();
    }

    [Then(@"The design template previews are not provided")]
    public void ThenDesignTemplatePreviewsAreNotProvided()
    {
        _designTemplateSteps.DesignTemplatePreviewsAreNotProvided();
    }
}