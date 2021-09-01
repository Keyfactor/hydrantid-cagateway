namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsCustomFields
    {
        string Tag { get;set; }
        string Label { get;set; }
        bool? Required { get;set; }
        bool? Modifiable { get;set; }
        string DefaultValue { get;set; }
    }
}