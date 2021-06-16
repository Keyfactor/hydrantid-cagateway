namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsCustomFields
    {
        string Tag { get; }
        string Label { get; }
        bool? Required { get; }
        bool? Modifiable { get; }
        string DefaultValue { get; }
    }
}