using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.CreateDesignTemplateFeature;

[Binding]
[Scope(Feature = "Create design template")]
public class CreateDesignTemplateStepDefinitions
{
    private readonly CreateDesignTemplateSteps _designTemplateSteps;

    public CreateDesignTemplateStepDefinitions()
    {
        _designTemplateSteps = new CreateDesignTemplateSteps(
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

    [Given(@"I create design template with name")]
    public void GivenICreateDesignTemplateWithName()
    {
        _designTemplateSteps.CreateDesignTemplateWithName();
    }

    [Given(@"I have created a new design template without name for user id")]
    public void GivenIHaveCreatedANewDesignTemplateWithoutNameForUserId()
    {
        _designTemplateSteps.CreateDesignTemplateWithoutName();
    }

    [When(@"I request for design template for user id")]
    public void WhenIRequestForDesignTemplateForUserId()
    {
        _designTemplateSteps.GetDesignTemplate();
    }

    [When(@"I create a design template with existing name")]
    public void WhenICreateADesignTemplateWithExistingName()
    {
        _designTemplateSteps.CreateDesignTemplateWithExistingName();
    }

    [Then(@"The design template is provided with name")]
    public void ThenTheDesignTemplateIsProvidedWithName()
    {
        _designTemplateSteps.DesignTemplateWithNameIsProvided();
    }

    [Then(@"The design template is not created")]
    public void ThenTheDesignTemplateIsNotCreated()
    {
        _designTemplateSteps.DesignTemplateIsNotCreated();
    }

    [Then(@"The design template is provided with default name")]
    public void ThenTheDesignTemplateIsProvidedWithDefaultName()
    {
        _designTemplateSteps.DesignTemplateWithDefaultNameIsProvided();
    }
}