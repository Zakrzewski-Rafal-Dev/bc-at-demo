using System.Text.Json.Serialization;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FontStyle
{
    Bold,
    Italic,
    Underline,
    InvalidStyle
}
