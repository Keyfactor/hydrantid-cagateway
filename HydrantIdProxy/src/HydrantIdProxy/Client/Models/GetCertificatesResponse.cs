using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertificatesResponse : ICertificatesResponse
    {
        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int? Count { get; }

        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<CertificatesResponseItem> Items { get; }

    }
}