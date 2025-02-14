namespace BrandingConfigurator.AcceptanceTests.Business.PrintProof.Model;

public class DecorationPrintProof
{
    public string PrintAreaId { get; set; }
    public string PrintTechniqueId { get; set; }
    public string MethodCode { get; set; }
    public string LocationCode { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int NumberOfColors { get; set; }
    public IEnumerable<string>? Colors { get; set; }
    public PrintProofArtwork ProofArtwork { get; set; }
    public IEnumerable<PrintProofArtwork>? RawArtworks { get; set; }
}