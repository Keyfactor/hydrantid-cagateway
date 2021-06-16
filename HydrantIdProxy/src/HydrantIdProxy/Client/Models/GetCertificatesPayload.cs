using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertificatesPayload : ICertificatesPayload
    {

        [DataMember(Name = "common_name", EmitDefaultValue = false)]
        public string CommonName { get;set; }

        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get;set; }

        [DataMember(Name = "not_before", EmitDefaultValue = false)]
        public DateTime? NotBefore { get;set; }

        [DataMember(Name = "not_after", EmitDefaultValue = false)]
        public DateTime? NotAfter { get;set; }

        [DataMember(Name = "expired", EmitDefaultValue = false)]
        public bool? Expired { get;set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public RevocationStatusEnum Status { get;set; }

        [DataMember(Name = "account", EmitDefaultValue = false)]
        public Guid? Account { get;set; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public Guid? Organization { get;set; }

        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public Guid? Policy { get;set; }

        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int? Limit { get;set; }

        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int? Offset { get;set; }

        [DataMember(Name = "sort_type", EmitDefaultValue = false)]
        public string SortType { get;set; }

        [DataMember(Name = "sort_direction", EmitDefaultValue = false)]
        public SortDirectionEnum SortDirection { get;set; }

        [DataMember(Name = "pem", EmitDefaultValue = false)]
        public bool? Pem { get;set; }

    }
}