using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class CmykToEdit
{
    public string? SourceCmykColorId { get; set; }
    public Cmyk? SourceCmykColor { get; set; }
    public Cmyk? DestinationCmykColor { get; set; }
    public bool IsHidden { get; set; }
}