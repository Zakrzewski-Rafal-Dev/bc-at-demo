using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Steps.CreateDesignFeature;

[Binding]
[Scope(Feature = "Create design")]
public class CreateDesignStepDefinitions
{
    private readonly CreateDesignSteps _designSteps;

    public CreateDesignStepDefinitions()
    {
        _designSteps = new CreateDesignSteps(
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I have created a new design")]
    public void GivenIHaveCreatedANewDesign()
    {
        _designSteps.CreateDesign();
    }

    [Given(@"UserId was not provided")]
    public void GivenUserIdWasNotProvided()
    {
        _designSteps.CreateDesignWithoutUserId();
    }

    [Given(@"I have created a new design without decorations")]
    public void GivenIHaveCreatedANewDesignWithoutDecorations()
    {
        _designSteps.CreateDesignWithoutDecorations();
    }

    [Given(@"I have created a new design with empty decoration")]
    public void GivenIHaveCreatedANewDesignWithEmptyDecoration()
    {
        _designSteps.CreateDesignWithEmptyDecoration();
    }

    [Given(@"I have created a new design with wrong print area id")]
    public void GivenIHaveCreatedANewDesignWithWrongPrintAreaId()
    {
        _designSteps.CreateDesignWithWrongPrintAreaId();
    }

    [Given(@"I have created a new design with wrong print technique id")]
    public void GivenIHaveCreatedANewDesignWithWrongPrintTechniqueId()
    {
        _designSteps.CreateDesignWithWrongPrintTechniqueId();
    }

    [Given(@"I have created a new design with wrong supplier item id")]
    public void GivenIHaveCreatedANewDesignWithWrongSupplierItemId()
    {
        _designSteps.CreateDesignWithWrongSupplierItemId();
    }

    [Given(@"I have created a new design with logo outside of print area")]
    public void GivenIHaveCreatedANewDesignWithLogoOutsideOfPrintArea()
    {
        _designSteps.CreateDesignWithLogoOutsideOfPrintArea();
    }

    [Given(@"I have created a new design with logo edge points outside of print area")]
    public void GivenIHaveCreatedANewDesignWithLogoEdgePointsOutsideOfPrintArea()
    {
        _designSteps.CreateDesignWithLogoEdgePointsOutsideOfPrintArea();
    }

    [Given(@"I have created a new design with wrong component id")]
    public void GivenIHaveCreatedANewDesignWithWrongComponentId()
    {
        _designSteps.CreateDesignWithWrongComponentId();
    }

    [Given(@"I have created a new design with variants")]
    public void GivenIHaveCreatedANewDesignWithVariants()
    {
        _designSteps.CreateDesignWithVariants();
    }

    [Given(@"I have created a new design with wrong id of variants")]
    public void GivenIHaveCreatedANewDesignWithWrongIdOfVariants()
    {
        _designSteps.CreateDesignWithWrongIdOfVariants();
    }

    [Given(@"I have created a new design with wrong model of variants")]
    public void GivenIHaveCreatedANewDesignWithWrongModelOfVariants()
    {
        _designSteps.CreateDesignWithWrongModelOfVariants();
    }

    [Given(@"I have created a new design with wrong value of angle of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfAngleOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfAngleOfLogo();
    }

    [Given(@"I have created a new design with wrong value of center point of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfCenterPointOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfCenterPointOfLogo();
    }

    [Given(@"I have created a new design with wrong value of width of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfWidthOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfWidthOfLogo();
    }

    [Given(@"I have created a new design with wrong value of height of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfHeightOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfHeightOfLogo();
    }

    [Given(@"I have created a new design with wrong value of scaled x of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfScaledXOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfScaledXOfLogo();
    }

    [Given(@"I have created a new design with wrong value of scaled y of logo")]
    public void GivenIHaveCreatedANewDesignWithWrongValueOfScaledYOfLogo()
    {
        _designSteps.CreateDesignWithWrongWrongValueOfScaledYOfLogo();
    }

    [When(@"I request for design")]
    public void WhenIRequestForDesign()
    {
        _designSteps.GetDesign();
    }

    [Then(@"The design is provided")]
    public void ThenTheDesignIsProvided()
    {
        _designSteps.TheDesignIsProvided();
    }

    [Then(@"The design is not created")]
    public void ThenTheDesignIsNotCreated()
    {
        _designSteps.TheDesignIsNotCreated();
    }
}
