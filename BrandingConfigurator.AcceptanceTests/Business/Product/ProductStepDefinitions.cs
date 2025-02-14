using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Product;

[Binding]
public class ProductStepDefinitions
{
    private readonly ProductSteps _productSteps;
    public ProductStepDefinitions()
    {
        _productSteps = new ProductSteps(new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [When(@"I request for product")]
    public void WhenIRequestForProduct()
    {
        _productSteps.GetProduct(Currency.SEK);
    }

    [When(@"I request for product with locale (.*)")]
    public void WhenIRequestForProductWithLocale(string locale)
    {
        _productSteps.GetProductWithLocale(Currency.SEK, locale);
    }

    [When(@"I request for product print techniques for locale (.*)")]
    public void WhenIRequestForProductPrintTechniquesForLocale(string locale)
    {
        _productSteps.GetProductPrintTechniquesForLocale(Currency.SEK, locale);
    }

    [Then(@"product is provided")]
    public void ThenProductIsProvided()
    {
        _productSteps.ProductIsProvided();
    }

    [Then(@"product is provided and translated to locale (.*)")]
    public void ThenTranslatedProductIsProvided(string locale)
    {
        _productSteps.TranslatedProductIsProvided(locale);
    }

    [Then(@"product print techniques is provided and translated to locale (.*)")]
    public void ThenProductWithTranslatedPrintTechniquesIsProvidedTranslated(string locale)
    {
        _productSteps.ProductWithTranslatedPrintTechniquesIsProvided(locale);
    }

    [When(@"I request for not existing product")]
    public void WhenIRequestForNotExistingProduct()
    {
        _productSteps.GetProductByNotExistingSupplierItemId();
    }

    [Then(@"error code instead of product is provided")]
    public void ThenErrorCodeInsteadOfProductIsProvided()
    {
        _productSteps.ErrorCodeInsteadOfProductIsProvided();
    }
    
    [When(@"I request for product prices in SEK")]
    public void WhenIRequestForProductPricesInSEK()
    {
        _productSteps.GetProductPrices(Currency.SEK);
    }

    [Then(@"product prices in SEK are provided")]
    public void ThenProductFromPricesInSEKAreProvided()
    {
        _productSteps.ProductPricesInAreProvided();
    }

    [When(@"I request for product prices in EUR")]
    public void WhenIRequestForProductPricesInEUR()
    {
        _productSteps.GetProductPrices(Currency.EUR);
    }

    [Then(@"product prices in EUR are provided")]
    public void ThenProductFromPricesInEURAreProvided()
    {
        _productSteps.ProductPricesInAreProvided();
    }
}
