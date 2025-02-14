using BrandingConfigurator.AcceptanceTests.Business.Image.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

public class Text
{
    public string Id { get; set; }
    public string? Path { get; set; }
    public TextFormatting? Formatting { get; set; }
    public IEnumerable<BasePoint<decimal>>? EdgePoints { get; set; }
}
