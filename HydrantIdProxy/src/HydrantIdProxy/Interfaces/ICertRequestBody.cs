using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBody
    {
        Guid? Policy { get; }
        string Csr { get; }
        CertRequestBodyValidity Validity { get; }
        CertRequestBodyDnComponents DnComponents { get; }
        CertRequestBodySubjectAltNames SubjectAltNames { get; }
        Dictionary<string, object> CustomFields { get; }
        Dictionary<string, object> CustomExtensions { get; }
        string Comment { get; }
        List<string> ExpiryEmails { get; }
        string ClearRemindersCertificateId { get; }
    }
}