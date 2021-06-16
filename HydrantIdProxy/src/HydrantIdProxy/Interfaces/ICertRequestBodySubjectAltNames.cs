using System.Collections.Generic;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodySubjectAltNames
    {
        List<string> Dnsname { get; }
        List<string> Ipaddress { get; }
        List<string> Rfc822Name { get; }
        List<string> Upn { get; }

    }
}