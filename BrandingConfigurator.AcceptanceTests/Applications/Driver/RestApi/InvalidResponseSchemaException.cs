using System.Net;

namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi
{
    public class InvalidResponseSchemaException : Exception
    {
        public InvalidResponseSchemaException(
            string expectedSchema,
            string retrievedContent)
        : base($"Invalid schema of response. Expected schema: {expectedSchema}, retrieved content: {retrievedContent}")
        {

        }
    }
}
