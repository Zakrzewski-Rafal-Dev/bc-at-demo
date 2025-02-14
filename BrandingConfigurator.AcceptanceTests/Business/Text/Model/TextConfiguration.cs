namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

public class TextConfiguration
{
    public IEnumerable<TextFont>? Fonts { get; set; }
    public IEnumerable<TextColor>? Colors { get; set; }
    public IEnumerable<FontStyle>? Styles { get; set; }
    public IEnumerable<FontAlignment>? Alignments { get; set; }
}
