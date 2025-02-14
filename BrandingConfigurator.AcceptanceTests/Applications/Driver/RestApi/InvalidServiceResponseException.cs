using System.Net;

namespace BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi
{
    public class InvalidServiceResponseException : Exception
    {
        public string ErrorDescription { get; }

        public InvalidServiceResponseException(
            HttpStatusCode expectedStatus, HttpStatusCode retrievedCode, string errorDescription = "")
            : base($"Invalid service response. Expected code {expectedStatus}, retrieved {retrievedCode}")
        {
            ErrorDescription = errorDescription;
        }
    }
}