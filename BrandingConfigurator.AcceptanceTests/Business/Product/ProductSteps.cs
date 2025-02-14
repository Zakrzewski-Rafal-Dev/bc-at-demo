using BrandingConfigurator.AcceptanceTests.Business.Price.Model;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Model;
using BrandingConfigurator.AcceptanceTests.Business.Product.Service;
using FluentAssertions;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Product;

public class ProductSteps
{
    private readonly IProductService _productService;
    private const string SupplierItemId = "21069017";
    private Model.Product? _product;
    private Exception _responseException;
    private ProductPrices _productPrices;
    private IEnumerable<PrintTechnique> _printTechniques;

    public ProductSteps(IProductService productService)
    {
        _productService = productService;
    }

    public void GetProduct(Currency currency)
    {
        _product = _productService.GetProduct(SupplierItemId, currency.ToString()).Result;
    }

    public void GetProductWithLocale(Currency currency, string locale)
    {
        _product = _productService.GetProduct(SupplierItemId, currency.ToString(), locale).Result;
    }

    public void GetProductPrintTechniquesForLocale(Currency currency, string locale)
    {
        _printTechniques = _productService.GetProductPrintTechniques(SupplierItemId, currency.ToString(), locale).Result;
    }

    public void ProductIsProvided()
    {
        AssertProductIsValid(Currency.SEK);
    }

    public void TranslatedProductIsProvided(string locale)
    {
        AssertProductIsValid(Currency.SEK);
        AssertProductIsTranslated(locale);
    }

    public void ProductWithTranslatedPrintTechniquesIsProvided(string locale)
    {
        AssertProductPrintTechniquesAreTranslated(locale);
    }

    public void GetProductByNotExistingSupplierItemId()
    {
        try
        {
            _product = _productService.GetProduct("foo", Currency.SEK.ToString()).Result;
        }
        catch (Exception ex)
        {
            _responseException = ex;
        }
    }

    public void ErrorCodeInsteadOfProductIsProvided()
    {
        Assert.AreEqual("One or more errors occurred. (Invalid service response. Expected code OK, retrieved NotFound)", _responseException.Message);
    }

    public void GetProductPrices(Currency currency)
    {
        _productPrices = _productService.GetProductPrices(SupplierItemId, currency.ToString()).Result;
    }

    public void ProductPricesInAreProvided()
    {
        AssertProductPricesAreValid();
    }

    private void AssertProductIsValid(Currency currency)
    {
        Assert.IsNotNull(_product);
        _product?.PrintAreas?.FirstOrDefault()?
            .PrintTechniques?.FirstOrDefault()
            .Should().NotBeNull();
    }

    private void AssertProductPricesAreValid()
    {
        Assert.IsNotNull(_productPrices);
        AssertPrintTechniquesPrices();
        AssertPrintAreaPrices();
        AssertPrintingPrices();
    }

    private void AssertPrintTechniquesPrices()
    {
        Assert.IsNotNull(_productPrices.PrintTechniquesPrices);
        Assert.That(_productPrices.PrintTechniquesPrices!.Count(), Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintTechniquesPrices?.FirstOrDefault());
        Assert.IsNotNull(_productPrices.PrintTechniquesPrices?.FirstOrDefault()?.PricesStartingFrom);
        Assert.That(_productPrices.PrintTechniquesPrices?.FirstOrDefault()?.PricesStartingFrom, Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintTechniquesPrices?.FirstOrDefault()?.Currency);
        Assert.IsNotNull(_productPrices.PrintTechniquesPrices?.FirstOrDefault()?.PrintTechniqueId);
    }

    private void AssertPrintAreaPrices()
    {
        Assert.IsNotNull(_productPrices.PrintAreaPrices);
        Assert.That(_productPrices.PrintAreaPrices!.Count(), Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintAreaPrices?.FirstOrDefault());
        Assert.IsNotNull(_productPrices.PrintAreaPrices?.FirstOrDefault()?.PricesStartingFrom);
        Assert.That(_productPrices.PrintAreaPrices?.FirstOrDefault()?.PricesStartingFrom, Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintAreaPrices?.FirstOrDefault()?.Currency);
        Assert.IsNotNull(_productPrices.PrintAreaPrices?.FirstOrDefault()?.PrintTechniqueId);
        Assert.IsNotNull(_productPrices.PrintAreaPrices?.FirstOrDefault()?.PrintAreaId);
    }

    private void AssertPrintingPrices()
    {
        Assert.IsNotNull(_productPrices.PrintingPrices);
        Assert.That(_productPrices.PrintingPrices!.Count(), Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault());
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.Price);
        Assert.That(_productPrices.PrintingPrices?.FirstOrDefault()?.Price, Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.Quantity);
        Assert.That(_productPrices.PrintingPrices?.FirstOrDefault()?.Quantity, Is.Not.Zero);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.DependentValue);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.DependentOn);
        Assert.That(_productPrices.PrintingPrices?.FirstOrDefault()?.DependentOn, Is.Not.Empty);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.DependentUnit);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.PrintTechniqueId);
        Assert.That(_productPrices.PrintingPrices?.FirstOrDefault()?.PrintTechniqueId, Is.Not.Empty);
        Assert.IsNotNull(_productPrices.PrintingPrices?.FirstOrDefault()?.Currency);
    }

    private void AssertProductIsTranslated(string locale)
    {
        if(locale == "sv_SE")
        {
            Assert.That(_product.PrintAreas.FirstOrDefault().LocationName, Is.EqualTo("runt"));
            Assert.That(_product.PrintAreas.FirstOrDefault().PrintTechniques.FirstOrDefault().MethodDescription, 
                Is.EqualTo("roterande screentryck"));
        }
        else
        {
            Assert.That(_product.PrintAreas.FirstOrDefault().LocationName, Is.EqualTo("wrap"));
            Assert.That(_product.PrintAreas.FirstOrDefault().PrintTechniques.FirstOrDefault().MethodDescription, 
                Is.EqualTo("Screenround"));
        }
    }

    private void AssertProductPrintTechniquesAreTranslated(string locale)
    {
        if(locale == "sv_SE")
        {
            Assert.That(_printTechniques.FirstOrDefault().MethodDescription, 
                Is.EqualTo("digitaltryckt etikett"));
            Assert.That(_printTechniques.FirstOrDefault().Description, 
                Does.Contain("Har du till exempel sett klistermärkena"));
        }
        else
        {
            Assert.That(_printTechniques.FirstOrDefault().MethodDescription, 
                Is.EqualTo("Digital sticker"));
            Assert.That(_printTechniques.FirstOrDefault().Description, 
                Does.Contain("Have you seen those cool stickers"));
        }
    }
}
