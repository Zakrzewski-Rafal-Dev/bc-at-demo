using BrandingConfigurator.AcceptanceTests.Business.Time;
using BrandingConfigurator.AcceptanceTests.Business.Time.Service;
using BrandingConfigurator.AcceptanceTests.Business.Time.Service.RestApi;
using Moq;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.UnitTests.Business.Time;

public class TimeStepUnitTests
{
    private TimeSteps _timeSteps;
    private Mock<ITimeService> _timeServiceMock;
    
    [SetUp]
    public void Init()
    {
        var time = new AcceptanceTests.Business.Time.Model.Time
        {
            Value = "foo"
        };
        _timeServiceMock = new Mock<ITimeService>();
        _timeServiceMock.Setup(x => x.GetTimeAsync()).ReturnsAsync(time);
        _timeSteps = new TimeSteps(_timeServiceMock.Object);
    } 
    
    [Test]
    public void GivenTimeService_WhenFetchServerTime_ThenCallTimeService()
    {
        _timeSteps.FetchServerTime();

        _timeServiceMock.Verify(x => x.GetTimeAsync());
    }
    
    [Test]
    public void GivenNonNullTimeFromTimeService_WhenValidateTime_ThenServerTimeIsProvided()
    {
        _timeSteps.FetchServerTime();
        
        _timeSteps.ServerTimeIsProvided();
    }
}