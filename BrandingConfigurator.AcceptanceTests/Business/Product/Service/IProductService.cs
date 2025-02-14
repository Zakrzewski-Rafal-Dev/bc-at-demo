using BrandingConfigurator.AcceptanceTests.Business.Product.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Product.Service;

public interface IProductService
{
    public Task<Model.Product> GetProduct(string supplierItemId, string priceCurrency);
    public Task<Model.Product> GetProduct(string supplierItemId, string priceCurrency, string locale);
    public Task<IEnumerable<PrintTechnique>> GetProductPrintTechniques(string supplierItemId, string priceCurrency, string locale);
    public Task<ProductPrices> GetProductPrices(string supplierItemId, string priceCurrency);
}
