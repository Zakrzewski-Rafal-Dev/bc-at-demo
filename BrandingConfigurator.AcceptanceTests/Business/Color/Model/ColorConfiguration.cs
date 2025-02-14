namespace BrandingConfigurator.AcceptanceTests.Business.Color.Model;

public class ColorConfiguration
{
    public IEnumerable<Pantone>? Colors { get; set; }
    public IEnumerable<Pantone>? PredefinedPantoneColors { get; set; }
    public IEnumerable<Cmyk>? PredefinedCmykColors { get; set; }
}
