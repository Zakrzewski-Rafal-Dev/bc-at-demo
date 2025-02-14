namespace BrandingConfigurator.AcceptanceTests.Business.File.Service;

public interface IFileService
{
    public Stream GetFile(string path);
}