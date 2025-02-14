using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.DesignTemplate.Model;

public class DesignTemplateId
{
    [JsonProperty("designTemplateId")]
    public string Id { get; set; }
}
