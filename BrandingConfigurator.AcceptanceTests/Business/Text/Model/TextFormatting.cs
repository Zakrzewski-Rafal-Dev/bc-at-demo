using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model
{
    public class TextFormatting
    {
        public string? FontName { get; set; }
        public string? PmsColor { get; set; }
        public Cmyk? CmykColor { get; set; }
        public int? FontSize { get; set; }
        public IEnumerable<FontStyle>? Styles { get; set; }
        public FontAlignment? Alignment { get; set; }
        public string? Value { get; set; }
    }
}