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
    ///     HawkCredentialComments
    /// </summary>
    [DataContract]
    public class HawkCredentialComments : IEquatable<HawkCredentialComments>, IValidatableObject, IHawkCredentialComments
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HawkCredentialComments" /> class.
        /// </summary>
        /// <param name="comments">comments.</param>
        public HawkCredentialComments(string comments = default)
        {
            Comments = comments;
        }

        /// <summary>
        ///     Gets or Sets Comments
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; }

        /// <summary>
        ///     Returns true if HawkCredentialComments instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredentialComments to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HawkCredentialComments input)
        {
            if (input == null)
                return false;

            return
                Comments == input.Comments ||
                Comments != null &&
                Comments.Equals(input.Comments);
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
            sb.Append("class HawkCredentialComments {\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
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
            return Equals(input as HawkCredentialComments);
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
                if (Comments != null)
                    hashCode = hashCode * 59 + Comments.GetHashCode();
                return hashCode;
            }
        }
    }
}