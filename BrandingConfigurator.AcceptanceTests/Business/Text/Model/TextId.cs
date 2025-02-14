using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

public class TextId
{
    [JsonProperty("textId")]
    public string Id { get; set; }
}
