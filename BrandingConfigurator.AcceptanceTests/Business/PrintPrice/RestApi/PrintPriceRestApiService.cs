using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Service;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice.RestApi;

public class PrintPriceRestApiService : RestService, IPrintPriceService
{
    private const string EndpointName = "/design";
    private const string ApiVersion1 = "1";
    private const string ApiVersion2 = "2";

    public PrintPriceRestApiService(TestRunConfiguration configuration, IRestDriver restDriver) :
        base(configuration, restDriver)
    {
    }

    public DesignPrintPrice CalculatePrintPrice(string designId, int? quantityOfProducts, string priceCurrency,
        string userId)
    {
        var uriString = BuildUriString(designId, quantityOfProducts, priceCurrency);
        var responseMessage = GetRestDriver()
            .CallGetMethodOnEndpointAsync(new Uri(uriString), userId, apiVersion: ApiVersion1)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentAsync(responseMessage).Result;
    }

    public DesignPrintPriceForVariants CalculatePrintPrice(string designId, VariantsForPrintPrices? variant,
        string userId)
    {
        var uriString = BuildUriStringForVariants(designId);
        var responseMessage = GetRestDriver()
            .CallCreateMethodOnEndpointAsync(
                new Uri(uriString),
                JsonContent.Create(variant), userId, apiVersion: ApiVersion2)
            .Result;

        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidServiceResponseException(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        return ReadResponseContentForVariantsAsync(responseMessage).Result;
    }

    protected override string GetServiceRelatedUrl()
    {
        return EndpointName;
    }

    private static async Task<DesignPrintPrice> ReadResponseContentAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<DesignPrintPrice>(await responseMessage.Content.ReadAsStringAsync());
    }

    private static async Task<DesignPrintPriceForVariants> ReadResponseContentForVariantsAsync(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<DesignPrintPriceForVariants>(await responseMessage.Content.ReadAsStringAsync());
    }

    private string BuildUriString(string designId, int? quantityOfProducts, string priceCurrency)
    {
        var uriString = GetEndpointServiceUrl() + $"/{designId}/printprice";
        uriString += quantityOfProducts != null ? $"?quantityOfProducts={quantityOfProducts}&" : "?";
        uriString += $"priceCurrency={priceCurrency}";
        
        return uriString;
    }
    
    private string BuildUriStringForVariants(string designId)
    {
        return GetEndpointServiceUrl() + $"s/{designId}/printprices";
    }
}