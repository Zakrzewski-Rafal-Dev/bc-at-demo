using BrandingConfigurator.AcceptanceTests.Business.Text.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Text.Service;

public interface ITextService
{
    TextConfiguration GetTextConfiguration(int pageNumber, int pageSize, string? filterValue);

    TextResponse CreateText(TextFormatting textFormatting, string userId);

    Model.Text GetTextMetadata(string textId, string userId);

    Stream GetTextFile(string url, string userId);
}
