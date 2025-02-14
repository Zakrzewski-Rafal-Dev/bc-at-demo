using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Text.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Text;

[Binding]
public class TextStepDefinitions
{
    private readonly TextSteps _textSteps;
    private const int PageNumber1 = 1;
    private const int PageSize100 = 100;
    private const string Filter = "";
    private const int PageNumber2 = 2;
    private const int PageSize4 = 4;

    public TextStepDefinitions()
    {
        _textSteps = new TextSteps(new TextRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I asked for text configuration")]
    public void GivenIAskedForTextConfiguration()
    {
        _textSteps.GetTextConfiguration(PageNumber1, PageSize100, Filter);
    }

    [Given(@"I created a new text")]
    public void GivenICreatedANewText()
    {
        _textSteps.CreateText();
    }

    [When(@"I ask for the text")]
    public void WhenIAskForTheText()
    {
        _textSteps.GetTextMetadata();
    }

    [Then(@"the image for text is returned")]
    public void ThenTheImageForTextIsReturned()
    {
        _textSteps.GetTextFile();
    }

    [When(@"I ask for paged text configuration")]
    public void WhenIAskFoPagedTextConfiguration()
    {
        _textSteps.GetTextConfiguration(PageNumber2, PageSize4, Filter);
    }

    [Then(@"The paged configuration is returned")]
    public void ThenThePagedConfigurationIsReturned()
    {
        _textSteps.PagedConfigurationIsReturned(PageSize4);
    }

    [When(@"I ask for filtered text configuration")]
    public void WhenIAskForFilteredTextConfiguration()
    {
        _textSteps.GetTextConfiguration(PageNumber1, PageSize100, "Dark Blue");
    }

    [Then(@"The filtered page is returned")]
    public void ThenTheFilteredPageIsReturned()
    {
        _textSteps.FilteredPageIsReturned();
    }

    [When(@"I create text with wrong font")]
    public void WhenICreateTextWithWrongFont()
    {
        _textSteps.CreateTextWithWrongFont();
    }

    [Then(@"Wrong font error is returned")]
    public void ThenWrongFontErrorIsReturned()
    {
        _textSteps.WrongFontErrorIsReturned();
    }

    [When(@"I create text with wrong pms color")]
    public void WhenICreateTextWithWrongPmsColor()
    {
        _textSteps.CreateTextWithWrongPmsColor();
    }

    [Then(@"Wrong pms color error is returned")]
    public void ThenWrongPmsColorErrorIsReturned()
    {
        _textSteps.WrongPmsErrorIsReturned();
    }

    [When(@"I create text with wrong cmyk color")]
    public void WhenICreateTextWithWrongCmykColor()
    {
        _textSteps.CreateTextWithWrongCmykColor();
    }

    [Then(@"Wrong cmyk color error is returned")]
    public void ThenWrongCmykColorErrorIsReturned()
    {
        _textSteps.CmykIsInvalidErrorIsReturned();
    }

    [When(@"I create text with two color types")]
    public void WhenICreateTextWithTwoColorTypes()
    {
        _textSteps.CreateTextWithTwoColorTypes();
    }

    [Then(@"Only one type of colors error is returned")]
    public void ThenOnlyOneTypeOfColorsErrorIsReturned()
    {
        _textSteps.OnlyOneTypeOfColorsErrorIsReturned();
    }

    [When(@"I create text with wrong style")]
    public void WhenICreateTextWithWrongStyle()
    {
        _textSteps.CreateTextWithWrongStyle();
    }

    [When(@"I create text with wrong alignment")]
    public void WhenICreateTextWithWrongAlignment()
    {
        _textSteps.CreateTextWithWrongAlignment();
    }

    [Then(@"Text formatting error is returned")]
    public void ThenTextFormattingErrorIsReturned()
    {
        _textSteps.TextFormattingErrorIsReturned();
    }

    [When(@"I ask for the not existing text")]
    public void WhenIAskForTheNotExistingText()
    {
        _textSteps.GetNotExistingTextMetadata();
    }

    [Then(@"NotFound error is returned")]
    public void ThenNotFoundErrorIsReturned()
    {
        _textSteps.NotFoundErrorIsReturned();
    }

    [When(@"I ask for the text with wrong graphic path")]
    public void WhenIAskForTheTextWithWrongGraphicPath()
    {
        _textSteps.GetNotExistingTextFile();
    }

}
