using BrandingConfigurator.AcceptanceTests.Business.Time.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Time
{
    public class TimeSteps
    {
        private readonly ITimeService _timeService;
        private Model.Time? _time;

        public TimeSteps(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void FetchServerTime()
        {
            _time = _timeService.GetTimeAsync().Result;
        }

        public void ServerTimeIsProvided()
        {
            Assert.True(_time != null && _time.IsValid());
        }
    }
}