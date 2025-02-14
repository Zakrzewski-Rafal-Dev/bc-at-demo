using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Steps.UpdateDesignFeature;

[Binding]
[Scope(Feature = "Update design")]
public class UpdateDesignStepDefinitions
{
    private readonly UpdateDesignSteps _designSteps;

    public UpdateDesignStepDefinitions()
    {
        _designSteps = new UpdateDesignSteps(
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I have created a new design")]
    public void GivenIHaveCreatedANewDesign()
    {
        _designSteps.CreateDesign();
    }

    [Given(@"I have created a new design without decorations")]
    public void GivenIHaveCreatedANewDesignWithoutDecorations()
    {
        _designSteps.CreateDesignWithoutDecorations();
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

    [When(@"I update the design")]
    public void WhenIUpdateTheDesign()
    {
        _designSteps.UpdateDesign();
    }

    [When(@"I update the design without UserId")]
    public void WhenIUpdateTheDesignWithoutUserId()
    {
        _designSteps.UpdateDesignWithoutUserId();
    }

    [When(@"I update the design by design without decorations")]
    public void WhenIUpdateTheDesignByDesignWithoutDecorations()
    {
        _designSteps.UpdateTheDesignByDesignWithoutDecorations();
    }

    [When(@"I update the design by design with wrong print area id")]
    public void WhenIUpdateTheDesignByDesignWithWrongPrintAreaId()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongPrintAreaId();
    }

    [When(@"I update the design by design with wrong print technique id")]
    public void WhenIUpdateTheDesignByDesignWithWrongPrintTechniqueId()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongPrintTechniqueId();
    }

    [When(@"I update the design by design with logo outside of print area")]
    public void WhenIUpdateTheDesignByDesignWithLogoOutsideOfPrintArea()
    {
        _designSteps.UpdateTheDesignByDesignWithLogoOutsideOfPrintArea();
    }

    [When(@"I update the design by design with wrong supplier item id")]
    public void WhenIUpdateTheDesignByDesignWithWrongSupplierItemId()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongSupplierItemId();
    }

    [When(@"I update the design by design with wrong component id")]
    public void WhenIUpdateTheDesignByDesignWithWrongComponentId()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongComponentId();
    }

    [When(@"I update the design by design with variants")]
    public void WhenIUpdateTheDesignByDesignWithVariants()
    {
        _designSteps.UpdateTheDesignByDesignWithVariants();
    }

    [When(@"I update the design by design with wrong id of variants")]
    public void WhenIUpdateTheDesignByDesignWithWrongIdsOfVariants()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongIdsOfVariants();
    }

    [When(@"I update the design by design with wrong model of variants")]
    public void WhenIUpdateTheDesignByDesignWithWrongModelOfVariants()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongModelOfVariants();
    }

    [When(@"I update the design with wrong value of angle of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfAngleOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfAngleOfLogo();
    }

    [When(@"I update the design with wrong value of center point of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfCenterPointOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfCenterPointOfLogo();
    }

    [When(@"I update the design with wrong value of width of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfWidthOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfWidthOfLogo();
    }

    [When(@"I update the design with wrong value of height of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfHeightOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfHeightOfLogo();
    }

    [When(@"I update the design with wrong value of scaled x of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfScaledXOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfScaledXOfLogo();
    }

    [When(@"I update the design with wrong value of scaled y of logo")]
    public void WhenIUpdateTheDesignByDesignWithWrongValueOfScaledYOfLogo()
    {
        _designSteps.UpdateTheDesignByDesignWithWrongValueOfScaledYOfLogo();
    }

    [Then(@"The design is updated")]
    public void ThenTheDesignIsUpdated()
    {
        _designSteps.TheDesignIsUpdated();
    }

    [Then(@"The design is not updated")]
    public void ThenTheDesignIsNotUpdated()
    {
        _designSteps.TheDesignIsNotUpdated();
    }
}
