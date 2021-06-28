using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsSubjectAltNames
    {
        PolicyDetailsSubjectAltNames.TagEnum? Tag { get;set; }
        string Label { get;set; }
        bool? Required { get;set; }
        bool? Modifiable { get;set; }
        string DefaultValue { get;set; }
    }
}