using BrandingConfigurator.AcceptanceTests.Business.PrintProof.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.PrintProof.Service;

public interface IPrintProofService
{
    public DesignPrintProof GetPrintProof(string designId);
}