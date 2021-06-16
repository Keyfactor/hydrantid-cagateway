using System.Collections.Generic;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodyDnComponents
    {
        string Cn { get; }
        List<string> Ou { get; }
        string O { get; }
        string L { get; }
        string St { get; }
        string C { get; }
        List<string> Dc { get; }

    }
}