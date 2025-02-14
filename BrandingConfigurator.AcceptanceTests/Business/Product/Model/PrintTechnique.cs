using BrandingConfigurator.AcceptanceTests.Business.Price.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Product.Model
{
    public class PrintTechnique
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? MethodCode { get; set; }
        public string? MethodDescription { get; set; }
        public string? PrintCode { get; set; }
        public string? MaxColors { get; set; }
        public Uri? ImageUrl { get; set; }
        public bool? IsRecommended { get; set; }
        public int? LeadTime { get; set; }
        public IEnumerable<PrintPricesLadder>? PrintPricesLadders { get; set; }
        public string? Description { get; set; }
    }
}
