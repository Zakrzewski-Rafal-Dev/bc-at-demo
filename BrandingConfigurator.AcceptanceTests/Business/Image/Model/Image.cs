namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class Image
{
    public string Id { get; set; }
    public string OriginalName { get; set; }
    public PantoneImage? PantoneImage { get; set; }
    public CmykImage? CmykImage { get; set; }
    public IEnumerable<BasePoint<decimal>>? EdgePoints { get; set; }
}