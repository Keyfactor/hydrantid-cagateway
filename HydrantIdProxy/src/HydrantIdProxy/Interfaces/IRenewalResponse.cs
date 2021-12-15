namespace Keyfactor.HydrantId.Interfaces
{
    public interface IRenewalResponse
    {
        string Id { get; set; }
        string RevocationStatus { get; set; }
    }
}