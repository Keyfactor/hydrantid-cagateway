namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsCustomExtensions
    {
        string Oid { get; }
        string Label { get; }
        bool? Required { get; }
        bool? Modifiable { get; }
        string DefaultValue { get; }
    }
}