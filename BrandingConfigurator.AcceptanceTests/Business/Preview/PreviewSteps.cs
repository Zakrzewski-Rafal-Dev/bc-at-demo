using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Business.File.Service;
using BrandingConfigurator.AcceptanceTests.Business.Preview.Model;
using BrandingConfigurator.AcceptanceTests.Business.Preview.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Preview;

public class PreviewSteps
{
    private const string UserId = "UserTestId";
    private const string InvalidDesignId = "InvalidDesignId";
    private readonly IFileService _fileService;
    private readonly IPreviewService _previewService;
    private DesignPreview _designPreview;
    private string _errorMessage;

    public PreviewSteps(
        IPreviewService previewService,
        IFileService fileService)
    {
        _previewService = previewService;
        _fileService = fileService;
    }

    public void GetPreview()
    {
        var designId = TestRunContext.GetInstance().DesignId;
        _designPreview = _previewService.GetPreview(designId, UserId);
    }

    public void PreviewIsProvided()
    {
        var designId = TestRunContext.GetInstance().DesignId;
        Assert.NotNull(_designPreview);
        Assert.IsNotEmpty(_designPreview.FileName);
        Assert.IsNotEmpty(_designPreview.Path);
        Assert.That(_designPreview.DesignId, Is.EqualTo(designId));
    }

    public void GetPreviewFile()
    {
        Assert.IsNotNull(_fileService.GetFile(_designPreview.Path));
    }

    public void GetPreviewForNotExistingDesign()
    {
        try
        {
            _designPreview = _previewService.GetPreview(InvalidDesignId, UserId);
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
    }

    public void PreviewFileIsNotProvided()
    {
        Assert.That(_errorMessage, Is.EqualTo("Invalid service response. Expected code OK, retrieved BadRequest"));
    }
}