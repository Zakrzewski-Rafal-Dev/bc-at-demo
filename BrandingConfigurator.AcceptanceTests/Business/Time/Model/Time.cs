namespace BrandingConfigurator.AcceptanceTests.Business.Time.Model
{
    public class Time
    {
        public string? Value { get; set; }

        public Boolean IsValid()
        {
            return !String.IsNullOrEmpty(Value);
        } 
    }
}