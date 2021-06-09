using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestBody
    {
        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        Guid? Policy { get; }

        /// <summary>
        ///     Gets or Sets Csr
        /// </summary>
        string Csr { get; }

        /// <summary>
        ///     Gets or Sets Validity
        /// </summary>
        CertRequestBodyValidity Validity { get; }

        /// <summary>
        ///     Gets or Sets DnComponents
        /// </summary>
        CertRequestBodyDnComponents DnComponents { get; }

        /// <summary>
        ///     Gets or Sets SubjectAltNames
        /// </summary>
        CertRequestBodySubjectAltNames SubjectAltNames { get; }

        /// <summary>
        ///     Gets or Sets CustomFields
        /// </summary>
        Dictionary<string, object> CustomFields { get; }

        /// <summary>
        ///     Gets or Sets CustomExtensions
        /// </summary>
        Dictionary<string, object> CustomExtensions { get; }

        /// <summary>
        ///     Gets or Sets Comment
        /// </summary>
        string Comment { get; }

        /// <summary>
        ///     Gets or Sets ExpiryEmails
        /// </summary>
        List<string> ExpiryEmails { get; }

        /// <summary>
        ///     Gets or Sets ClearRemindersCertificateId
        /// </summary>
        string ClearRemindersCertificateId { get; }

        /// <summary>
        ///     Returns true if CertRequestBody instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBody to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestBody input);

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        string ToString();

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        string GetJson();

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(object input);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        int GetHashCode();
    }
}