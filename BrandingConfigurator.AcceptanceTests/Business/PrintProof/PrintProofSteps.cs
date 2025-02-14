using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Business.File.Service;
using BrandingConfigurator.AcceptanceTests.Business.PrintProof.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintProof.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintProof;

public class PrintProofSteps
{
    private const string InvalidDesignId = "InvalidDesignId";
    private readonly IPrintProofService _printProofService;
    private readonly IFileService _fileService;
    private DesignPrintProof _designPrintProof;
    private string _errorMessage;

    public PrintProofSteps(
        IPrintProofService printProofService,
        IFileService fileService)
    {
        _printProofService = printProofService;
        _fileService = fileService;
    }

    public void GetPrintProof()
    {
        var designId = TestRunContext.GetInstance().DesignId;
        _designPrintProof = _printProofService.GetPrintProof(designId);
    }

    public void PrintProofIsProvided()
    {
        Assert.IsNotNull(_designPrintProof);
        Assert.IsNotNull(_designPrintProof.PrintProofs);
        AssertPrintProofs();
    }

    public void GetPrintProofFile()
    {
        foreach (var decorationPrintProof in _designPrintProof.PrintProofs)
        {
            Assert.IsNotNull(_fileService.GetFile(decorationPrintProof.ProofArtwork.Path));
        }
    }

    public void GetPrintPriceForNotExistingDesign()
    {
        try
        {
            _designPrintProof = _printProofService.GetPrintProof(InvalidDesignId);
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
    }

    public void PrintProofFileIsNotProvided()
    {
        Assert.That(_errorMessage, Is.EqualTo("Invalid service response. Expected code OK, retrieved BadRequest"));
    }

    private void AssertPrintProofs()
    {
        foreach (var decorationPrintProof in _designPrintProof.PrintProofs)
        {
            Assert.IsNotNull(decorationPrintProof);
            AssertPrintProof(decorationPrintProof);
        }
    }

    private static void AssertPrintProof(DecorationPrintProof decorationPrintProof)
    {
        Assert.IsNotNull(decorationPrintProof.PrintAreaId);
        Assert.IsNotNull(decorationPrintProof.PrintTechniqueId);
        Assert.IsNotNull(decorationPrintProof.MethodCode);
        Assert.IsNotNull(decorationPrintProof.LocationCode);
        Assert.That(decorationPrintProof.Height, Is.GreaterThanOrEqualTo(0));
        Assert.That(decorationPrintProof.Width, Is.GreaterThanOrEqualTo(0));
        Assert.IsNotNull(decorationPrintProof.Colors);
        Assert.That(decorationPrintProof.Colors?.Count(), Is.EqualTo(2));
        Assert.That(decorationPrintProof.NumberOfColors, Is.EqualTo(2));
        Assert.IsNotEmpty(decorationPrintProof.ProofArtwork.Name);
        Assert.IsNotEmpty(decorationPrintProof.ProofArtwork.Path);
        Assert.IsNotEmpty(decorationPrintProof.RawArtworks?.FirstOrDefault()?.Name);
        Assert.IsNotEmpty(decorationPrintProof.RawArtworks?.FirstOrDefault()?.Path);
    }
}