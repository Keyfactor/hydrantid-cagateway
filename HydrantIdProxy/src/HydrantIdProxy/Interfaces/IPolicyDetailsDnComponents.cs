using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsDnComponents
    {
        PolicyDetailsDnComponents.TagEnum? Tag { get; }
        string Label { get; }
        bool? Required { get; }
        bool? Modifiable { get; }
        string DefaultValue { get; }
        bool? CopyAsFirstSan { get; }
    }
}