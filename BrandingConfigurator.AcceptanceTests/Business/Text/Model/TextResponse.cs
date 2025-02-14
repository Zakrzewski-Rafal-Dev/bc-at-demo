using System.Net;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Model;

public class TextResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Content { get; set; }
}
