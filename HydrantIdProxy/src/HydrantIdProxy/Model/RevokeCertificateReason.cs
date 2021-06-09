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
    ///     RevokeCertificateReason
    /// </summary>
    [DataContract]
    public class RevokeCertificateReason : IEquatable<RevokeCertificateReason>, IValidatableObject, IRevokeCertificateReason
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RevokeCertificateReason" /> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public RevokeCertificateReason(RevocationReasons reason = default)
        {
            Reason = reason;
        }

        /// <summary>
        ///     Gets or Sets Reason
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public RevocationReasons Reason { get; }

        /// <summary>
        ///     Returns true if RevokeCertificateReason instances are equal
        /// </summary>
        /// <param name="input">Instance of RevokeCertificateReason to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RevokeCertificateReason input)
        {
            if (input == null)
                return false;

            return
                Reason == input.Reason ||
                Reason.Equals(input.Reason);
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
            sb.Append("class RevokeCertificateReason {\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
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
            return Equals(input as RevokeCertificateReason);
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
                return hashCode;
            }
        }
    }
}