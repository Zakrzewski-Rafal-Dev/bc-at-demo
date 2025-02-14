using System.Text.Json.Serialization;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FontAlignment
{
    Left,
    Center,
    Right,
    InvalidAlignment
}
