using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     HawkCredentialDeleteResults
    /// </summary>
    [DataContract]
    public class HawkCredentialDeleteResults : IEquatable<HawkCredentialDeleteResults>, IValidatableObject, IHawkCredentialDeleteResults
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HawkCredentialDeleteResults" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="deleted">deleted.</param>
        public HawkCredentialDeleteResults(string id = default, bool? deleted = default)
        {
            Id = id;
            Deleted = deleted;
        }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        ///     Gets or Sets Deleted
        /// </summary>
        [DataMember(Name = "deleted", EmitDefaultValue = false)]
        public bool? Deleted { get; }

        /// <summary>
        ///     Returns true if HawkCredentialDeleteResults instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredentialDeleteResults to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HawkCredentialDeleteResults input)
        {
            if (input == null)
                return false;

            return
                (
                    Id == input.Id ||
                    Id != null &&
                    Id.Equals(input.Id)
                ) &&
                (
                    Deleted == input.Deleted ||
                    Deleted != null &&
                    Deleted.Equals(input.Deleted)
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
            sb.Append("class HawkCredentialDeleteResults {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
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
            return Equals(input as HawkCredentialDeleteResults);
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Deleted != null)
                    hashCode = hashCode * 59 + Deleted.GetHashCode();
                return hashCode;
            }
        }
    }
}