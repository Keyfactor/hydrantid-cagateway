using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestBody : ICertRequestBody
    {
        public CertRequestBody()
        {

        }

        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public Guid? Policy {get;set; }

        [DataMember(Name = "csr", EmitDefaultValue = false)]
        public string Csr {get;set; }

        [DataMember(Name = "validity", EmitDefaultValue = false)]
        public CertRequestBodyValidity Validity {get;set; }

        [DataMember(Name = "dnComponents", EmitDefaultValue = false)]
        public CertRequestBodyDnComponents DnComponents {get;set; }

        [DataMember(Name = "subjectAltNames", EmitDefaultValue = false)]
        public CertRequestBodySubjectAltNames SubjectAltNames {get;set; }

        [DataMember(Name = "customFields", EmitDefaultValue = false)]
        public Dictionary<string, object> CustomFields {get;set; }

        [DataMember(Name = "customExtensions", EmitDefaultValue = false)]
        public Dictionary<string, object> CustomExtensions {get;set; }

        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string Comment {get;set; }

        [DataMember(Name = "expiryEmails", EmitDefaultValue = false)]
        public List<string> ExpiryEmails {get;set; }

        [DataMember(Name = "clearRemindersCertificateId", EmitDefaultValue = false)]
        public string ClearRemindersCertificateId {get;set; }
    }
}