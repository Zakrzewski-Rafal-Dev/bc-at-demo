namespace BrandingConfigurator.AcceptanceTests.Business.Design.Model;

public class Decoration
{
    public string PrintAreaId { get; set; }
    public string PrintTechniqueId { get; set; }
    public string PreviewPath { get; set; }
    public string? LocationName { get; set; }
    public string? MethodName { get; set; }
    public IEnumerable<Layer> Layers { get; set; }
}