using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Color.Service;

public interface IColorService
{
    public ColorConfiguration GetColorConfiguration(int pageNumber, int pageSize, string filter);
}
