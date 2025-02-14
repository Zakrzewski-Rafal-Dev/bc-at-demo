using System.Net;
using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Time.Service.RestApi;
using Moq;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.UnitTests.Business.Time.Service.RestApi;

public class TimeRestApiServiceUnitTests
{
    private TestRunConfiguration _testRunConfiguration;
    private Mock<IRestDriver> _restDriverMock;
    private Uri _uri;

    [SetUp]
    public void Init()
    {
        _testRunConfiguration = new TestRunConfiguration
        {
            Url = "https://localhost:8080/api"
        };
        _uri = new Uri("https://localhost:8080/api/time");
        _restDriverMock = new Mock<IRestDriver>();
    }

    [Test]
    public void GivenSerializedTimeInHttpResponse_WhenGettingTime_ThenReturnSerializedTime()
    {
        HttpContent content = new StringContent("{\"value\": \"foo\"}");
        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK, 
            Content = content
        };
        _restDriverMock
            .Setup(x => x.CallGetMethodOnEndpointAsync(_uri,It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(httpResponseMessage);
        var timeRestApiService = new TimeRestApiService(_testRunConfiguration, _restDriverMock.Object);

        var timeAsync = timeRestApiService.GetTimeAsync();

        Assert.That(timeAsync.Result.Value, Is.EqualTo("foo"));
        _restDriverMock.Verify(x => x.CallGetMethodOnEndpointAsync(_uri, It.IsAny<string>(), It.IsAny<string>()));
    }
    
    [Test]
    public void GivenNotFoundErrorCodeInHttpResponse_WhenGettingTime_ThenThrowException()
    {
        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound
        };
        _restDriverMock
            .Setup(x => x.CallGetMethodOnEndpointAsync(_uri , It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(httpResponseMessage);
        var timeRestApiService = new TimeRestApiService(_testRunConfiguration, _restDriverMock.Object);

        Assert.ThrowsAsync<InvalidServiceResponseException>( async () => await timeRestApiService.GetTimeAsync());
    }
    
    [Test]
    public void GivenWrongSchemaInHttpResponse_WhenValidate_ThenThrowException()
    {
        HttpContent content = new StringContent("{\"wrongValue\": \"foo\"}");
        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = content
        };
        _restDriverMock
            .Setup(x => x.CallGetMethodOnEndpointAsync(_uri,It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(httpResponseMessage);
        var timeRestApiService = new TimeRestApiService(_testRunConfiguration, _restDriverMock.Object);

        Assert.ThrowsAsync<InvalidResponseSchemaException>( async () => await timeRestApiService.GetTimeAsync());
    }
}