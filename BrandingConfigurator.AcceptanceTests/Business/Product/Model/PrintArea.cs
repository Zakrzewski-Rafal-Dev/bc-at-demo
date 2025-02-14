namespace BrandingConfigurator.AcceptanceTests.Business.Product.Model
{
    public class PrintArea
    {
        public string? ReferenceId { get; set; }
        public string? LocationName { get; set; }
        public string? LocationCode { get; set; }
        public Uri? MainImageUrl { get; set; }
        public Uri? PreviewImageUrl { get; set; }
        public decimal CoordinateTopLeftX { get; set; }
        public decimal CoordinateTopLeftY { get; set; }
        public decimal CoordinateTopRightX { get; set; }
        public decimal CoordinateTopRightY { get; set; }
        public decimal CoordinateBottomLeftX { get; set; }
        public decimal CoordinateBottomLeftY { get; set; }
        public decimal CoordinateBottomRightX { get; set; }
        public decimal CoordinateBottomRightY { get; set; }
        public int WidthMm { get; set; }
        public int HeightMm { get; set; }
        public int DiameterMm { get; set; }
        public IEnumerable<PrintTechnique>? PrintTechniques { get; set; }
    }
}
