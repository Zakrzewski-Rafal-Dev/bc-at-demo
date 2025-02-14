using BrandingConfigurator.AcceptanceTests.Business.Image.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Design.Model;

public class Layer
{
    public decimal? Angle { get; set; }
    public BasePoint<decimal>? CenterPoint { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public decimal? ScaledX { get; set; }
    public decimal? ScaledY { get; set; }
    public ComponentType ComponentType { get; set; }
    public string ComponentId { get; set; }
    public Coordinates Coordinates { get; set; }
    public IEnumerable<BasePoint<int>> EdgePoints { get; set; }
}
