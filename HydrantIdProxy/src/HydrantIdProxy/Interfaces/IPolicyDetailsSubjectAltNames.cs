using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsSubjectAltNames
    {
        PolicyDetailsSubjectAltNames.TagEnum? Tag { get; }
        string Label { get; }
        bool? Required { get; }
        bool? Modifiable { get; }
        string DefaultValue { get; }
    }
}