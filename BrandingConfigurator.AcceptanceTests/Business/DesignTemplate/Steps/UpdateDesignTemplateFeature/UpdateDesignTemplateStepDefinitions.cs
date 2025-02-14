using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.UpdateDesignTemplateFeature;

[Binding]
[Scope(Feature = "Update design template")]
public class UpdateDesignTemplateStepDefinitions
{
    private readonly UpdateDesignTemplateSteps _designTemplateSteps;

    public UpdateDesignTemplateStepDefinitions()
    {
        _designTemplateSteps = new UpdateDesignTemplateSteps(
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

    [Given(@"I have created a new design and design template with supplierItemId not matching")]
    public void GivenIHaveCreatedANewDesignAndDesignTemplateWithSupplierItemIdNotMatching()
    {
        _designTemplateSteps.CreateDesignAndDesignTemplateWithoutSupplierItemIdNotMatching();
    }

    [When(@"I update design template")]
    public void WhenIUpdateDesignTemplate()
    {
        _designTemplateSteps.UpdateDesignTemplate();
    }

    [When(@"I update design template with design with not matching supplierItemId")]
    public void WhenIUpdateDesignTemplateWithDesignWithNotMatchingSupplierItemId()
    {
        _designTemplateSteps.UpdateDesignTemplateWithDesignWithNotMatchingSupplierItemId();
    }

    [When(@"I update design template that does not exist")]
    public void WhenIUpdateDesignTemplateThatDoesNotExist()
    {
        _designTemplateSteps.UpdateDesignTemplateThatDoesNotExist();
    }

    [When(@"I update design template with design that does not exist")]
    public void WhenIUpdateDesignTemplateWithDesignThatDoesNotExist()
    {
        _designTemplateSteps.UpdateDesignTemplateWithDesignThatDoesNotExist();
    }

    [Then(@"The design template is updated")]
    public void ThenTheDesignTemplateIsUpdated()
    {
        _designTemplateSteps.DesignTemplateIsUpdated();
    }

    [Then(@"The design template is not updated")]
    public void ThenTheDesignTemplateIsNotUpdated()
    {
        _designTemplateSteps.DesignTemplateIsNotUpdated();
    }
}