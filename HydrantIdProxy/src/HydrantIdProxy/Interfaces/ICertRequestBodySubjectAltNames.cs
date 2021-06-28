using System.Collections.Generic;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodySubjectAltNames
    {
        List<string> Dnsname { get;set; }
        List<string> Ipaddress { get;set; }
        List<string> Rfc822Name { get;set; }
        List<string> Upn { get;set; }

    }
}