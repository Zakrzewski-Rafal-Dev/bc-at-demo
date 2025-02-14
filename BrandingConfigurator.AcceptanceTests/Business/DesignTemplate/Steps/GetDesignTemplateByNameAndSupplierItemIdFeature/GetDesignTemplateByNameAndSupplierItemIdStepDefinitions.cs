using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Steps.GetDesignTemplateByNameAndSupplierItemIdFeature;

[Binding]
[Scope(Feature = "Get design template by name and supplierItemId")]
public class GetDesignTemplateByNameAndSupplierItemIdStepDefinitions
{
    private readonly GetDesignTemplateByNameAndSupplierItemIdSteps _designTemplateSteps;

    public GetDesignTemplateByNameAndSupplierItemIdStepDefinitions()
    {
        _designTemplateSteps = new GetDesignTemplateByNameAndSupplierItemIdSteps(
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

    [When(@"I request for design template by name and supplierItemId for user id")]
    public void WhenIRequestForDesignTemplateByNameAndSupplierItemIdForUserId()
    {
        _designTemplateSteps.GetDesignTemplateByNameAndSupplierItemId();
    }

    [When(@"I request for design template with name and without supplierItemId for user id")]
    public void WhenIRequestForDesignTemplateByNameAndWithoutSupplierItemIdForUserId()
    {
        _designTemplateSteps.GetDesignTemplateByNameAndWithoutSupplierItemId();
    }

    [When(@"I request for design template without name and with supplierItemId for user id")]
    public void WhenIRequestForDesignTemplateWithoutNameAndWithSupplierItemIdForUserId()
    {
        _designTemplateSteps.GetDesignTemplateWithoutNameAndWithSupplierItemIdForUserId();
    }

    [When(@"I request for design template by name and supplierItemId for user id and locale (.*)")]
    public void WhenIRequestForDesignTemplateByNameForUserIdAndLocale(string locale)
    {
        _designTemplateSteps.GetDesignTemplateByNameAndSupplierItemIdLocale(locale);
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

    [Then(@"The design template is provided with name and translated to locale (.*)")]
    public void ThenTheDesignTemplateIsProvidedWithNameAndTranslated(string locale)
    {
        _designTemplateSteps.DesignTemplateWithNameIsProvidedAndTranslated(locale);
    }
}