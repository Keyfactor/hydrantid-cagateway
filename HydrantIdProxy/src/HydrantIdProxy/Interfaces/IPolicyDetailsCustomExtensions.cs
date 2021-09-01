namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsCustomExtensions
    {
        string Oid { get;set; }
        string Label { get;set; }
        bool? Required { get;set; }
        bool? Modifiable { get;set; }
        string DefaultValue { get;set; }
    }
}