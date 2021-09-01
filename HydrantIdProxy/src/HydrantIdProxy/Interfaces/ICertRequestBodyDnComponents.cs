using System.Collections.Generic;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodyDnComponents
    {
        string Cn { get;set; }
        List<string> Ou { get;set; }
        string O { get;set; }
        string L { get;set; }
        string St { get;set; }
        string C { get;set; }
        List<string> Dc { get;set; }

    }
}