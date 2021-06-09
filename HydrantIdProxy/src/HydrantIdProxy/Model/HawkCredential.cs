using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     HawkCredential
    /// </summary>
    [DataContract]
    public class HawkCredential : IEquatable<HawkCredential>, IValidatableObject, IHawkCredential
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HawkCredential" /> class.
        /// </summary>
        /// <param name="id">HAWK Identifier (required).</param>
        /// <param name="key">HAWK Key - *Only returned on create or roll*.</param>
        /// <param name="comments">Comment for HAWK credential.</param>
        /// <param name="lastUsed">Date/time HAWK credential last used.</param>
        /// <param name="createdAt">Date/time HAWK credential created (required).</param>
        /// <param name="updatedAt">Date/time HAWK credential updated (required).</param>
        public HawkCredential(string id = default, string key = default, string comments = default,
            DateTime? lastUsed = default, DateTime? createdAt = default, DateTime? updatedAt = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for HawkCredential and cannot be null");
            Id = id;
            // to ensure "createdAt" is required (not null)
            if (createdAt == null)
                throw new InvalidDataException(
                    "createdAt is a required property for HawkCredential and cannot be null");
            CreatedAt = createdAt;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
                throw new InvalidDataException(
                    "updatedAt is a required property for HawkCredential and cannot be null");
            UpdatedAt = updatedAt;
            Key = key;
            Comments = comments;
            LastUsed = lastUsed;
        }

        /// <summary>
        ///     HAWK Identifier
        /// </summary>
        /// <value>HAWK Identifier</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        ///     HAWK Key - *Only returned on create or roll*
        /// </summary>
        /// <value>HAWK Key - *Only returned on create or roll*</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; }

        /// <summary>
        ///     Comment for HAWK credential
        /// </summary>
        /// <value>Comment for HAWK credential</value>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; }

        /// <summary>
        ///     Date/time HAWK credential last used
        /// </summary>
        /// <value>Date/time HAWK credential last used</value>
        [DataMember(Name = "lastUsed", EmitDefaultValue = false)]
        public DateTime? LastUsed { get; }

        /// <summary>
        ///     Date/time HAWK credential created
        /// </summary>
        /// <value>Date/time HAWK credential created</value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///     Date/time HAWK credential updated
        /// </summary>
        /// <value>Date/time HAWK credential updated</value>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime? UpdatedAt { get; }

        /// <summary>
        ///     Returns true if HawkCredential instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredential to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HawkCredential input)
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
                    Key == input.Key ||
                    Key != null &&
                    Key.Equals(input.Key)
                ) &&
                (
                    Comments == input.Comments ||
                    Comments != null &&
                    Comments.Equals(input.Comments)
                ) &&
                (
                    LastUsed == input.LastUsed ||
                    LastUsed != null &&
                    LastUsed.Equals(input.LastUsed)
                ) &&
                (
                    CreatedAt == input.CreatedAt ||
                    CreatedAt != null &&
                    CreatedAt.Equals(input.CreatedAt)
                ) &&
                (
                    UpdatedAt == input.UpdatedAt ||
                    UpdatedAt != null &&
                    UpdatedAt.Equals(input.UpdatedAt)
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
            sb.Append("class HawkCredential {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
            sb.Append("  LastUsed: ").Append(LastUsed).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
            return Equals(input as HawkCredential);
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
                if (Key != null)
                    hashCode = hashCode * 59 + Key.GetHashCode();
                if (Comments != null)
                    hashCode = hashCode * 59 + Comments.GetHashCode();
                if (LastUsed != null)
                    hashCode = hashCode * 59 + LastUsed.GetHashCode();
                if (CreatedAt != null)
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                if (UpdatedAt != null)
                    hashCode = hashCode * 59 + UpdatedAt.GetHashCode();
                return hashCode;
            }
        }
    }
}