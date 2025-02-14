using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class CmykImage
{
    public string? Path { get; set; }
    public IEnumerable<Cmyk>? Colors { get; set; }
    public IEnumerable<CmykImageColor>? CmykColors { get; set; }
}