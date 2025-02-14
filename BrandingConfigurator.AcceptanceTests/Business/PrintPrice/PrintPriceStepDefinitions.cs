using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Design.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Product.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintPrice;

[Binding]
public class PrintPriceStepDefinitions
{
    private readonly PrintPriceSteps _printPriceSteps;

    public PrintPriceStepDefinitions()
    {
        _printPriceSteps = new PrintPriceSteps(
            new PrintPriceRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new DesignRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new ProductRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }
    
    [Given(@"I have uploaded an image")]
    public void GivenIHaveUploadedAnImage()
    {
        _printPriceSteps.UploadImage();
    }

    [Given(@"I have created a design with a print area whose print price depends on the size of the logo")]
    public void GivenIHaveCreatedDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo()
    {
        _printPriceSteps.CreateDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo();
    }

    [Given(@"I have created a design with a print area whose print price depend on the number of colors")]
    public void GivenIHaveCreatedDesignWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors()
    {
        _printPriceSteps.CreateDesignWithPrintAreaWhosePrintPriceDependOnTheNumberOfColors();
    }

    [Given(@"I have created a design with a print area whose print price is fixed")]
    public void GivenIHaveCreatedDesignWithPrintAreaWhosePrintPriceIsFixed()
    {
        _printPriceSteps.CreateDesignWithPrintAreaWhosePrintPriceIsFixed();
    }

    [Given(@"I have created a design")]
    public void GivenIHaveCreatedDesign()
    {
        _printPriceSteps.CreateDesignWithPrintAreaWhosePrintPriceDependsOnTheSizeOfTheLogo();
    }
    
    [Given(@"I have created an empty design")]
    public void GivenIHaveCreatedAnEmptyDesign()
    {
        _printPriceSteps.CreateAnEmptyDesign();
    }
    
    [Given(@"I have created an design with one print area and one print technique")]
    public void GivenIHaveCreatedAnDesignWithOnePrintAreaAndOnePrintTechnique()
    {
        _printPriceSteps.CreateAnDesignWithOnePrintAreaAndOnePrintTechnique();
    }

    [Given(@"I have created an design with many print area and one print technique")]
    public void GivenIHaveCreatedAnDesignWithManyPrintAreasAndOnePrintTechnique()
    {
        _printPriceSteps.CreateAnDesignWithManyPrintAreasAndOnePrintTechnique();
    }

    [Given(@"I have created an design with many print areas and many print techniques")]
    public void GivenIHaveCreatedAnDesignWithManyPrintAreasAndManyPrintTechniques()
    {
        _printPriceSteps.CreateAnDesignWithManyPrintAreasAndManyPrintTechniques();
    }
    
    [When(@"I request for print price for the design")]
    public void WhenIRequestForPrintPriceForTheDesign()
    {
        _printPriceSteps.CalculatePrintPriceInSek();
    }
    
    [When(@"I request for print price in SEK for the design")]
    public void WhenIRequestForPrintPriceInSekForTheDesign()
    {
        _printPriceSteps.CalculatePrintPriceInSek();
    }

    [When(@"I request for print price in wrong currency for the design")]
    public void WhenIRequestForPrintPriceInWrongCurrencyForTheDesign()
    {
        _printPriceSteps.CalculatePrintPriceInWrongCurrency();
    }

    [When(@"I request for print price for not existing design")]
    public void WhenIRequestForPrintPriceForNotExistingDesign()
    {
        _printPriceSteps.CalculatePrintPriceForNotExistingDesign();
    }

    [When(@"I request for print price in EUR for the design")]
    public void WhenIRequestForPrintPriceInEur()
    {
        _printPriceSteps.CalculatePrintPriceInEur();
    }

    [When(@"I request for print price for zero product quantity")]
    public void WhenIRequestForPrintPriceForZeroProductQuantity()
    {
        _printPriceSteps.CalculatePrintPriceForZeroProductQuantity();
    }

    [When(@"I request for print price for negative product quantity")]
    public void WhenIRequestForPrintPriceForNegativeProductQuantity()
    {
        _printPriceSteps.CalculatePrintPriceForNegativeProductQuantity();
    }

    [When(@"I request for print price without product quantity")]
    public void WhenIRequestForPrintPriceForWithoutProductQuantity()
    {
        _printPriceSteps.CalculatePrintPriceWithoutProductQuantity();
    }
    
    [When(@"I request for print price for variants")]
    public void WhenIRequestForPrintPriceForVariants()
    {
        _printPriceSteps.CalculatePrintPriceForVariantsInSek();
    }

    [When(@"I request for print price in SEK for variants")]
    public void WhenIRequestForPrintPriceInSekForVariants()
    {
        _printPriceSteps.CalculatePrintPriceInSekForVariants();
    }

    [When(@"I request for print price in wrong currency for variants")]
    public void WhenIRequestForPrintPriceInWrongCurrencyForVariants()
    {
        _printPriceSteps.CalculatePrintPriceInWrongCurrencyForVariants();
    }

    [When(@"I request for print price in EUR for variants")]
    public void WhenIRequestForPrintPriceInEurForVariants()
    {
        _printPriceSteps.CalculatePrintPriceInEurForVariants();
    }

    [When(@"I request for print price for zero product quantity of variants")]
    public void WhenIRequestForPrintPriceForZeroProductQuantityOfVariants()
    {
        _printPriceSteps.CalculatePrintPriceForZeroProductQuantityOfVariants();
    }

    [When(@"I request for print price for negative product quantity of variants")]
    public void WhenIRequestForPrintPriceForNegativeProductQuantityOfVariants()
    {
        _printPriceSteps.CalculatePrintPriceForNegativeProductQuantityOfVariants();
    }
    
    [When(@"I request for print price without variants")]
    public void WhenIRequestForPrintPriceWithoutVariants()
    {
        _printPriceSteps.CalculatePrintPriceWithoutVariants();
    }
    
    [When("I request for lead time for the design")]
    public void WhenIRequestForLeadTimeForTheDesign()
    {
        _printPriceSteps.CalculateLeadTimeForDesign();
    }
    
    [When("I request for lead time for variants")]
    public void WhenIRequestForLeadTimeForVariants()
    {
        _printPriceSteps.CalculateLeadTimeForVariants();
    }

    [When("I request for lead time for the design and quantity below preferential threshold")]
    public void WhenIRequestForLeadTimeForTheDesignAndQuantityBelowPreferentialThreshold()
    {
        _printPriceSteps.CalculateLeadTimeForDesignAndQuantityBelowPreferentialThreshold();
    }
    
    [When("I request for lead time for variants and quantity below preferential threshold")]
    public void WhenIRequestForLeadTimeForVariantsAndQuantityBelowPreferentialThreshold()
    {
        _printPriceSteps.CalculateLeadTimeForVariantsAndQuantityBelowPreferentialThreshold();
    }
    
    [When("I request for lead time for the design and quantity above preferential threshold")]
    public void WhenIRequestForLeadTimeForTheDesignAndQuantityAbovePreferentialThreshold()
    {
        _printPriceSteps.CalculateLeadTimeForDesignAndQuantityAbovePreferentialThreshold();
    }
    
    [When("I request for lead time for variants and quantity above preferential threshold")]
    public void WhenIRequestForLeadTimeForVariantsAndQuantityAbovePreferentialThreshold()
    {
        _printPriceSteps.CalculateLeadTimeForVariantsAndQuantityAbovePreferentialThreshold();
    }
    
    [Then(@"The valid print price is returned")]
    public void ThenTheValidPrintPriceIsReturned()
    {
        _printPriceSteps.PrintPriceInSekIsValid();
    }

    [Then(@"The valid print price in SEK is returned")]
    public void ThenTheValidPrintPriceInSekIsReturned()
    {
        _printPriceSteps.PrintPriceInSekIsValid();
    }

    [Then(@"The valid print price in EUR is returned")]
    public void ThenTheValidPrintPricePrintPriceInEurIsReturned()
    {
        _printPriceSteps.PrintPriceInEurIsValid();
    }
    
    [Then(@"The valid print price for variants is returned")]
    public void ThenTheValidPrintPriceForVariantsIsReturned()
    {
        _printPriceSteps.PrintPriceForVariantsInSekIsValid();
    }

    [Then(@"The valid print price for variants in SEK is returned")]
    public void ThenTheValidPrintPriceForVariantsInSekIsReturned()
    {
        _printPriceSteps.PrintPriceForVariantsInSekIsValid();
    }

    [Then(@"The valid print price for variants in EUR is returned")]
    public void ThenTheValidPrintPricePrintForVariantsPriceInEurIsReturned()
    {
        _printPriceSteps.PrintPriceForVariantsInEurIsValid();
    }

    [Then(@"Error code instead of print price is returned")]
    public void ThenErrorCodeInsteadOfPrintPriceIsReturned()
    {
        _printPriceSteps.ErrorCodeInsteadOfPrintPriceIsReturned();
    }

    [Then(@"The zero print price is returned")]
    public void ThenTheZeroPrintPriceIsReturned()
    {
        _printPriceSteps.PrintPriceIsZero();
    }

    [Then(@"The zero lead time is always returned")]
    public void ThenTheZeroLeadTimeIsAlwaysReturned()
    {
        _printPriceSteps.LeadTimeIsAlwaysZero();
    }

    [Then(@"The zero print price and no variants is returned")]
    public void ThenZeroPrintPriceAndNoVariantsIsReturned()
    {
        _printPriceSteps.ZeroPrintPriceAndNoVariantsIsReturned();
    }

    [Then(@"The zero print price for variants is returned")]
    public void ThenZeroPrintPriceForVariantsIsReturned()
    {
        _printPriceSteps.ZeroPrintPriceForVariantsIsReturned();
    }
    
    [Then(@"The one day lead time is returned")]
    public void ThenTheOneDayLeadTimeIsReturned()
    {
        _printPriceSteps.LeadTimeIsOneDay();
    }

    [Then(@"The standard lead time is returned")]
    public void ThenTheStandardLeadTimeIsReturned()
    {
        _printPriceSteps.StandardLeadTimeIsReturned();
    }
    
    [Then(@"The extended one lead time is returned")]
    public void ThenTheExtendedOneLeadTimeIsReturned()
    {
        _printPriceSteps.ExtendedOneLeadTimeIsReturned();
    }

    [Then(@"The extended standard lead time is returned")]
    public void ThenTheExtendedStandardLeadTimeIsReturned()
    {
        _printPriceSteps.ExtendedStandardLeadTimeIsReturned();
    }
    
    [Then(@"The combined standard lead time is returned")]
    public void ThenTheCombinedStandardLeadTimeIsReturned()
    {
        _printPriceSteps.CombinedStandardLeadTimeIsReturned();
    }
    
    [Then(@"Print prices are not given")]
    public void ThenPrintPricesAreNotGiven()
    {
        _printPriceSteps.PrintPricesAreNotGiven();
    }
}