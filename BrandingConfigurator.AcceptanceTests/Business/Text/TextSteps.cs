using BrandingConfigurator.AcceptanceTests.Business.Color.Model;
using BrandingConfigurator.AcceptanceTests.Business.Text.Model;
using BrandingConfigurator.AcceptanceTests.Business.Text.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Text;

public class TextSteps
{
    private const string UserId = "UserTestId";
    private readonly ITextService _textService;
    private Model.Text _text = new();
    private TextConfiguration _textConfiguration = new();
    private string _errorMessage;

    public TextSteps(ITextService textService) 
    {
        _textService = textService;
    }

    public void GetTextConfiguration(int pageNumber, int pageSize, string? filter)
    {
        _textConfiguration = _textService.GetTextConfiguration(pageNumber, pageSize, filter);
    }

    public void CreateText()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id,
            FontSize = 10,
            Value = "Test"
        };
        _text.Id = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void CreateTextWithWrongFont()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name + "WrongFont",
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id,
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content; 
    }

    public void CreateTextWithWrongPmsColor()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id + "Wrong Color",
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void CreateTextWithWrongCmykColor()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            CmykColor = new Cmyk { C = 1, M = 1, Y = 1, K = 2 },
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void CreateTextWithTwoColorTypes()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id,
            CmykColor = new Cmyk { C = 1, M = 1, Y = 1, K = 1 },
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void CreateTextWithWrongStyle()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { FontStyle.InvalidStyle },
            Alignment = _textConfiguration.Alignments.FirstOrDefault(),
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id,
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void CreateTextWithWrongAlignment()
    {
        var textFormatting = new TextFormatting
        {
            FontName = _textConfiguration.Fonts.FirstOrDefault().Name,
            Styles = new List<FontStyle> { _textConfiguration.Styles.FirstOrDefault() },
            Alignment = FontAlignment.InvalidAlignment,
            PmsColor = _textConfiguration.Colors.FirstOrDefault().Id,
            FontSize = 10,
            Value = "Test"
        };
        _errorMessage = _textService.CreateText(textFormatting, UserId).Content;
    }

    public void GetTextMetadata()
    {
        _text = _textService.GetTextMetadata(_text.Id, UserId);
        Assert.That(_text.EdgePoints.Count(), Is.GreaterThan(0));
    }

    public void GetNotExistingTextMetadata()
    {
        try
        {
            _text = _textService.GetTextMetadata(_text.Id + "invalidId", UserId);
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
    }

    public void GetNotExistingTextFile()
    {
        try
        {
            _textService.GetTextFile("/file/text/someInvalidPath.svg", UserId);
        }
        catch(Exception ex)
        {
            _errorMessage = ex.Message;
        }
    }

    public void GetTextFile()
    {
        Assert.IsNotNull(_textService.GetTextFile(_text.Path, UserId));
    }

    public void PagedConfigurationIsReturned(int pageSize)
    {
        Assert.That(_textConfiguration.Colors, Is.Not.Null);
        Assert.That(_textConfiguration.Colors.Count, Is.EqualTo(pageSize));
        Assert.That(_textConfiguration.Colors.ToList()[0].Name, Is.EqualTo("Medium Purple C"));
        Assert.That(_textConfiguration.Colors.ToList()[0].CssColor, Is.EqualTo("#4E008E"));
        Assert.That(_textConfiguration.Colors.ToList()[1].Name, Is.EqualTo("Pink C"));
        Assert.That(_textConfiguration.Colors.ToList()[1].CssColor, Is.EqualTo("#D62598"));
        Assert.That(_textConfiguration.Colors.ToList()[2].Name, Is.EqualTo("Process Black C"));
        Assert.That(_textConfiguration.Colors.ToList()[2].CssColor, Is.EqualTo("#27251F"));
        Assert.That(_textConfiguration.Colors.ToList()[3].Name, Is.EqualTo("Process Blue C"));
        Assert.That(_textConfiguration.Colors.ToList()[3].CssColor, Is.EqualTo("#0085CA"));
    }

    public void FilteredPageIsReturned()
    {
        Assert.That(_textConfiguration.Colors, Is.Not.Null);
        Assert.That(_textConfiguration.Colors.Count, Is.EqualTo(1));
        Assert.That(_textConfiguration.Colors.ToList()[0].Name, Is.EqualTo("Dark Blue C"));
        Assert.That(_textConfiguration.Colors.ToList()[0].CssColor, Is.EqualTo("#00239C"));
    }

    public void WrongFontErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("Font: ArialWrongFont is invalid. "));
    }

    public void WrongPmsErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("Color: 6cea8ee1-22b6-4be7-a850-bcec2075ad0cWrong Color is invalid. "));
    }
    

    public void OnlyOneTypeOfColorsErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("Only one type of color should be provided. "));
    }

    public void CmykIsInvalidErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("K value of CMYK must be between 0 and 1, but was: 2 "));
    }

    public void TextFormattingErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("Text formatting object is missing."));
    }

    public void NotFoundErrorIsReturned()
    {
        Assert.That(_errorMessage, Is.EqualTo("Invalid service response. Expected code OK, retrieved NotFound"));
    }
}
