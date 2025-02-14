using BrandingConfigurator.AcceptanceTests.Business.Preview.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Preview.Service;

public interface IPreviewService
{
    public DesignPreview GetPreview(string designId, string userId);
}