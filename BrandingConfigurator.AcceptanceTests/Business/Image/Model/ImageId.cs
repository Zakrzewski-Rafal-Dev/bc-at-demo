using Newtonsoft.Json;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class ImageId
{
    [JsonProperty("imageId")]
    public string Id { get; set; }
}
