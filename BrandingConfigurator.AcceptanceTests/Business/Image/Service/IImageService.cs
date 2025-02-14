using BrandingConfigurator.AcceptanceTests.Business.Image.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Service;

public interface IImageService
{
    public string UploadImage(Stream memoryStream, string fileName, string userId);
    public string EditImage(string imageId, string userId, ImageFormatting imageFormatting);
    public Model.Image GetImageMetadata(string imageId, string userId);
    public IEnumerable<Model.Image> GetImagesMetadata(string userId, Paging? paging);
    public void DeleteImage(string imageId, string userId);
}
