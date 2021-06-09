using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Enums;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     RevokeCertificateReasonIssuerDN
    /// </summary>
    [DataContract]
    public class RevokeCertificateReasonIssuerDn : IEquatable<RevokeCertificateReasonIssuerDn>, IValidatableObject, IRevokeCertificateReasonIssuerDn
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RevokeCertificateReasonIssuerDn" /> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        /// <param name="issuerDn">Issuer distinguished name.</param>
        public RevokeCertificateReasonIssuerDn(RevocationReasons reason = default, string issuerDn = default)
        {
            Reason = reason;
            IssuerDn = issuerDn;
        }

        /// <summary>
        ///     Gets or Sets Reason
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public RevocationReasons Reason { get; }

        /// <summary>
        ///     Issuer distinguished name
        /// </summary>
        /// <value>Issuer distinguished name</value>
        [DataMember(Name = "issuerDN", EmitDefaultValue = false)]
        public string IssuerDn { get; }

        /// <summary>
        ///     Returns true if RevokeCertificateReasonIssuerDN instances are equal
        /// </summary>
        /// <param name="input">Instance of RevokeCertificateReasonIssuerDN to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RevokeCertificateReasonIssuerDn input)
        {
            if (input == null)
                return false;

            return
                (
                    Reason == input.Reason ||
                    Reason.Equals(input.Reason)
                ) &&
                (
                    IssuerDn == input.IssuerDn ||
                    IssuerDn != null &&
                    IssuerDn.Equals(input.IssuerDn)
                );
        }

        /// <summary>
        ///     To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RevokeCertificateReasonIssuerDN {\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  IssuerDN: ").Append(IssuerDn).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as RevokeCertificateReasonIssuerDn);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                hashCode = hashCode * 59 + Reason.GetHashCode();
                if (IssuerDn != null)
                    hashCode = hashCode * 59 + IssuerDn.GetHashCode();
                return hashCode;
            }
        }
    }
}