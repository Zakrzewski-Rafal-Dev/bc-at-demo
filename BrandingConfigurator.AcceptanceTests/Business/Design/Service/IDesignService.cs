namespace BrandingConfigurator.AcceptanceTests.Business.Design.Service;

public interface IDesignService
{
    public string CreateDesign(Model.Design design, string userId);
    public void UpdateDesign(Model.Design design, string userId);
    public Model.Design GetDesign(string designId, string userId);
    public string CreateDesignTemplate(string designId, string? name, string userId);
}
