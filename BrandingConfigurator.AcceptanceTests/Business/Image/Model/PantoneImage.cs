using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class PantoneImage
{
    public string? Path { get; set; }
    public IEnumerable<Pantone>? Colors { get; set; }
    public IEnumerable<PantoneImageColor>? PantoneColors { get; set; }
}
