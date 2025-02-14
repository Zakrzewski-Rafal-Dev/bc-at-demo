using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

namespace BrandingConfigurator.Domain.PrintPrice.Model;

public class PrintAreaPrice
{
    public decimal PricesStartingFrom { get; set; }
    public string PrintTechniqueId { get; set; }
    public string PrintAreaId  { get; set; }
    public Currency? Currency { get; set; }
}
