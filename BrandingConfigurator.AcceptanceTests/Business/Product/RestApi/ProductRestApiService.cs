using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using Newtonsoft.Json;
using System.Net;

namespace BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

public class ProductRestApiService : RestService, IProductService
{
    private const string EndpointName = "/product";

    public ProductRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public async Task<Model.Product> GetProduct(string supplierItemId, string priceCurrency)
    {
        var responseMessage = await GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{supplierItemId}?priceCurrency={priceCurrency}"));

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return await ReadResponseContentAsync(responseMessage);
    }

    public async Task<Model.Product> GetProduct(string supplierItemId, string priceCurrency, string locale)
    {
        var responseMessage = await GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{supplierItemId}?priceCurrency={priceCurrency}&locale={locale}"));

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return await ReadResponseContentAsync(responseMessage);
    }

    public async Task<ProductPrices> GetProductPrices(string supplierItemId, string priceCurrency)
    {
        var responseMessage = await GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{supplierItemId}/prices?priceCurrency={priceCurrency}"));

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return JsonConvert.DeserializeObject<ProductPrices>(await responseMessage.Content.ReadAsStringAsync());
    }

    public async Task<IEnumerable<PrintTechnique>> GetProductPrintTechniques(string supplierItemId, string priceCurrency, string locale)
    {
        var responseMessage = await GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(GetEndpointServiceUrl() + $"/{supplierItemId}/printtechniques?priceCurrency={priceCurrency}&locale={locale}"));

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return JsonConvert.DeserializeObject<IEnumerable<PrintTechnique>>(await responseMessage.Content.ReadAsStringAsync());
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }

    private async Task<Model.Product> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<Model.Product>(await responseMessage.Content.ReadAsStringAsync());
    }
}
