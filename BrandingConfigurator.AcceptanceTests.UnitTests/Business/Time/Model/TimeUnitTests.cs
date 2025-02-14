using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.UnitTests.Business.Time.Model;

public class TimeUnitTests
{
    [Test]
    public void GivenNotNullOrEmptyValueOfTime_WhenIsValid_ThenTimeIsValid()
    {
        var time = new AcceptanceTests.Business.Time.Model.Time
        {
            Value = "foo"
        };

        var result = time.IsValid();

        Assert.True(result);
    }
    
    [Test]
    public void GivenEmptyValueOfTime_WhenIsValid_ThenTimeIsInvalid()
    {
        var time = new AcceptanceTests.Business.Time.Model.Time
        {
            Value = ""
        };

        var result = time.IsValid();

        Assert.False(result);
    }
    
    [Test]
    public void GivenNullValueOfTime_WhenIsValid_ThenTimeIsInvalid()
    {
        var time = new AcceptanceTests.Business.Time.Model.Time
        {
            Value = null
        };

        var result = time.IsValid();

        Assert.False(result);
    }
}