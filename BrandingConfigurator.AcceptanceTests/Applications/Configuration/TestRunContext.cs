namespace BrandingConfigurator.AcceptanceTests.Applications.Configuration;

public sealed class TestRunContext
{
    private static TestRunContext _instance;

    private TestRunContext()
    {
    }

    public static TestRunContext GetInstance()
    {
        return _instance ??= new TestRunContext();
    }

    public string? DesignId { get; set; }
}