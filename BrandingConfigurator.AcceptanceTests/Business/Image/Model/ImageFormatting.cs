namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class ImageFormatting
{
    public IEnumerable<ColorsToReplace>? ColorsToReplace { get; set; }
    public IEnumerable<PantoneToEdit>? PantonesToEdit { get; set; }
    public IEnumerable<CmykToEdit>? CmyksToEdit { get; set; }
}
