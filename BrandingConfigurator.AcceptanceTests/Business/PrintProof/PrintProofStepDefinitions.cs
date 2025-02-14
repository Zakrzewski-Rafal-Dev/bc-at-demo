using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.File.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.PrintProof.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintProof;

[Binding]
public class PrintProofStepDefinitions
{
    private readonly PrintProofSteps _printProofSteps;

    public PrintProofStepDefinitions()
    {
        _printProofSteps = new PrintProofSteps(
            new PrintProofRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new FileRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I request for print proof for not existing design")]
    public void GivenIRequestForPrintProofForNotExistingDesign()
    {
        _printProofSteps.GetPrintPriceForNotExistingDesign();
    }

    [When(@"I request for print proof for design")]
    public void WhenIRequestForPrintProofForThisDesign()
    {
        _printProofSteps.GetPrintProof();
    }

    [Then(@"The print proof is provided")]
    public void ThenThePrintProofIsProvided()
    {
        _printProofSteps.PrintProofIsProvided();
    }

    [Then(@"Print proof file is provided when requested")]
    public void ThenPrintProofFileIsProvidedWhenRequested()
    {
        _printProofSteps.GetPrintProofFile();
    }

    [Then(@"Print proof file is not provided")]
    public void ThenPrintProofFileIsNotProvided()
    {
        _printProofSteps.PrintProofFileIsNotProvided();
    }
}