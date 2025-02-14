using BrandingConfigurator.AcceptanceTests.Business.PrintPrice.Model;

namespace BrandingConfigurator.Domain.PrintPrice.Model;

public class PrintTechniquePrice
{
    public decimal PricesStartingFrom { get; set; }
    public string PrintTechniqueId { get; set; }
    public Currency? Currency { get; set; }
}
