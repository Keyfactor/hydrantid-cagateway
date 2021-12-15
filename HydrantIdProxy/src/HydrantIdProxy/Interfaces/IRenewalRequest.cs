namespace Keyfactor.HydrantId.Interfaces
{
    public interface IRenewalRequest
    {
        bool ReuseCsr { get; set; }
        string Csr { get; set; }
    }
}