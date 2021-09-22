namespace Keyfactor.HydrantId.Interfaces
{
    public interface IHawkCredentialDeleteResults
    {
        string Id { get;set; }
        bool? Deleted { get;set; }
    }
}