using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class ColorsToReplace
{
    public Cmyk? SourceCmykColor { get; set; }
    public Cmyk? DestinationCmykColor { get; set; }
    public string? SourcePantoneColorId { get; set; }
    public string? DestinationPantoneColorId { get; set; }
}