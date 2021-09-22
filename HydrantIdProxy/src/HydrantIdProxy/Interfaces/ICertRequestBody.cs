using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBody
    {
        Guid? Policy { get;set; }
        string Csr { get;set; }
        CertRequestBodyValidity Validity { get;set; }
        CertRequestBodyDnComponents DnComponents { get;set; }
        CertRequestBodySubjectAltNames SubjectAltNames { get;set; }
        Dictionary<string, object> CustomFields { get;set; }
        Dictionary<string, object> CustomExtensions { get;set; }
        string Comment { get;set; }
        List<string> ExpiryEmails { get;set; }
        string ClearRemindersCertificateId { get;set; }
    }
}