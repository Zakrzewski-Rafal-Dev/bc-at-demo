using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;

public class RestApiResponseValidator
{
    private readonly HttpResponseMessage _response;

    public RestApiResponseValidator(HttpResponseMessage response)
    {
        _response = response;
    }

    public void ValidateStatusCode(HttpStatusCode statusCode)
    {
        if (!IsValidateStatusCode(statusCode))
        {
            throw new InvalidServiceResponseException(statusCode, ResponseStatusCode());
        }
    }

    public void ValidateSchema(string schema)
    {
        if (!IsSchemaValid(schema))
        {
            throw new InvalidResponseSchemaException(schema, GetResponseContent());
        }
    }

    private Boolean IsValidateStatusCode(HttpStatusCode statusCode)
    {
        return ResponseStatusCode() == statusCode;
    }

    private HttpStatusCode ResponseStatusCode()
    {
        return _response.StatusCode;
    }

    private Boolean IsSchemaValid(string schema)
    {
        var jsonObject = GetJsonObjectFromResponseContent();
        var jsonSchema = GetJsonSchemaFrom(schema);

        return jsonObject.IsValid(jsonSchema);
    }
        
    private JObject GetJsonObjectFromResponseContent()
    {
        return JObject.Parse(GetResponseContent());
    }
        
    private string GetResponseContent()
    {
        return _response.Content.ReadAsStringAsync().Result;
    }

    private static JSchema GetJsonSchemaFrom(string schema)
    {
        return JSchema.Parse(schema);
    }
}