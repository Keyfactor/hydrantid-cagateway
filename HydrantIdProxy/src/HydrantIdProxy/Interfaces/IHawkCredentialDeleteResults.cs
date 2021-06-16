namespace Keyfactor.HydrantId.Interfaces
{
    public interface IHawkCredentialDeleteResults
    {
        string Id { get; }
        bool? Deleted { get; }
    }
}