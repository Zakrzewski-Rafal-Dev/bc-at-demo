namespace BrandingConfigurator.AcceptanceTests.Business.Time.Service
{
    public interface ITimeService
    {
        public Task<Model.Time> GetTimeAsync();
    }
}