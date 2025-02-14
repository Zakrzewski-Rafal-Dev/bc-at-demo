using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Steps.GetDesignFeature;

[Binding]
[Scope(Feature = "Get design")]
public class GetDesignStepDefinitions
{
    private readonly GetDesignSteps _designSteps;

    public GetDesignStepDefinitions()
    {
        _designSteps = new GetDesignSteps(
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I have created a new design")]
    public void GivenIHaveCreatedANewDesign()
    {
        _designSteps.CreateDesign();
    }

    [Given(@"I have created a new design with variants")]
    public void GivenIHaveCreatedANewDesignWithVariants()
    {
        _designSteps.CreateDesignWithVariants();
    }

    [When(@"I request for design")]
    public void WhenIRequestForDesign()
    {
        _designSteps.GetDesign();
    }

    [When(@"I request for design without UserId")]
    public void WhenIRequestForDesignWithoutUserId()
    {
        _designSteps.GetDesignWithoutUserId();
    }

    [When(@"I request for not existing design")]
    public void WhenIRequestForNotExistingDesign()
    {
        _designSteps.GetNotExistingDesign();
    }

    [Then(@"The design is provided")]
    public void ThenTheDesignIsProvided()
    {
        _designSteps.TheDesignIsProvided();
    }

    [Then(@"The design is not provided")]
    public void ThenTheDesignIsNotProvided()
    {
        _designSteps.DesignIsNotProvided();
    }

    [Then(@"The design is not returned")]
    public void ThenTheDesignIsNotReturned()
    {
        _designSteps.TheDesignIsNotReturned();
    }
}
