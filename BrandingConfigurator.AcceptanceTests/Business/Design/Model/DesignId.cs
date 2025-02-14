using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Model;

public class DesignId
{
    [JsonProperty("designId")]
    public string Id { get; set; }
}
