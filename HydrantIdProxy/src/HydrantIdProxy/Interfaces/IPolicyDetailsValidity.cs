using System.Collections.Generic;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsValidity
    {
        List<string> Years { get;set; }
        List<string> Months { get;set; }
        List<string> Days { get;set; }
        bool? Required { get;set; }
        bool? Modifiable { get;set; }
    }
}