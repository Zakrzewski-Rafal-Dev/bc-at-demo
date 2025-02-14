using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.File.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Preview.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Preview;

[Binding]
public class PreviewStepDefinitions
{
    private readonly PreviewSteps _previewSteps;

    public PreviewStepDefinitions()
    {
        _previewSteps = new PreviewSteps(
            new PreviewRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new FileRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I request for preview for not existing design")]
    public void GivenIRequestForPreviewForNotExistingDesign()
    {
        _previewSteps.GetPreviewForNotExistingDesign();
    }

    [When(@"I request for preview for design")]
    public void WhenIRequestForPreviewForDesign()
    {
        _previewSteps.GetPreview();
    }

    [Then(@"The design preview is provided")]
    public void ThenTheDesignPreviewIsProvided()
    {
        _previewSteps.PreviewIsProvided();
    }

    [Then(@"Design preview file is provided when requested")]
    public void ThenDesignPreviewFileIsProvidedWhenRequested()
    {
        _previewSteps.GetPreviewFile();
    }

    [Then(@"Design preview file is not provided")]
    public void ThenDesignPreviewFileIsNotProvided()
    {
        _previewSteps.PreviewFileIsNotProvided();
    }
}