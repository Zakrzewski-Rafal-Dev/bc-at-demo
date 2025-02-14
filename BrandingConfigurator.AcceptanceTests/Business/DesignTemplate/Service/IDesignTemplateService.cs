using BrandingConfigurator.AcceptanceTests.Business.Image.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Service;

public interface IDesignTemplateService
{
    public void DeleteDesignTemplate(string designTemplateId, string userId);
    public Model.DesignTemplate GetDesignTemplate(string designTemplateId, string userId);
    public Model.DesignTemplate GetDesignTemplate(string designTemplateId, string userId, string locale);
    public Model.DesignTemplate GetDesignTemplateByNameAndSupplierItemId(string name, string supplierItemId, string userId);
    public Model.DesignTemplate GetDesignTemplateByNameAndSupplierItemId(string name, string supplierItemId, string userId,string locale);
    public IEnumerable<Model.DesignTemplate> GetDesignTemplates(string userId, Paging paging, string name = null);
    public IEnumerable<Model.DesignTemplate> GetDesignTemplates(string userId, Paging paging, string locale, string name = null);
    public void UpdateDesignTemplate(string designId, string designTemplateId, string userId);
}