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
    ///     PolicyDetailsValidity
    /// </summary>
    [DataContract]
    public class PolicyDetailsValidity : IEquatable<PolicyDetailsValidity>, IValidatableObject, IPolicyDetailsValidity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolicyDetailsValidity" /> class.
        /// </summary>
        /// <param name="years">years.</param>
        /// <param name="months">months.</param>
        /// <param name="days">days.</param>
        /// <param name="required">required.</param>
        /// <param name="modifiable">modifiable.</param>
        public PolicyDetailsValidity(string years = default, string months = default, string days = default,
            bool? required = default, bool? modifiable = default)
        {
            Years = years;
            Months = months;
            Days = days;
            Required = required;
            Modifiable = modifiable;
        }

        /// <summary>
        ///     Gets or Sets Years
        /// </summary>
        [DataMember(Name = "years", EmitDefaultValue = false)]
        public string Years { get; }

        /// <summary>
        ///     Gets or Sets Months
        /// </summary>
        [DataMember(Name = "months", EmitDefaultValue = false)]
        public string Months { get; }

        /// <summary>
        ///     Gets or Sets Days
        /// </summary>
        [DataMember(Name = "days", EmitDefaultValue = false)]
        public string Days { get; }

        /// <summary>
        ///     Gets or Sets Required
        /// </summary>
        [DataMember(Name = "required", EmitDefaultValue = false)]
        public bool? Required { get; }

        /// <summary>
        ///     Gets or Sets Modifiable
        /// </summary>
        [DataMember(Name = "modifiable", EmitDefaultValue = false)]
        public bool? Modifiable { get; }

        /// <summary>
        ///     Returns true if PolicyDetailsValidity instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetailsValidity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyDetailsValidity input)
        {
            if (input == null)
                return false;

            return
                (
                    Years == input.Years ||
                    Years != null &&
                    Years.Equals(input.Years)
                ) &&
                (
                    Months == input.Months ||
                    Months != null &&
                    Months.Equals(input.Months)
                ) &&
                (
                    Days == input.Days ||
                    Days != null &&
                    Days.Equals(input.Days)
                ) &&
                (
                    Required == input.Required ||
                    Required != null &&
                    Required.Equals(input.Required)
                ) &&
                (
                    Modifiable == input.Modifiable ||
                    Modifiable != null &&
                    Modifiable.Equals(input.Modifiable)
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
            sb.Append("class PolicyDetailsValidity {\n");
            sb.Append("  Years: ").Append(Years).Append("\n");
            sb.Append("  Months: ").Append(Months).Append("\n");
            sb.Append("  Days: ").Append(Days).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Modifiable: ").Append(Modifiable).Append("\n");
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
            return Equals(input as PolicyDetailsValidity);
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
                if (Years != null)
                    hashCode = hashCode * 59 + Years.GetHashCode();
                if (Months != null)
                    hashCode = hashCode * 59 + Months.GetHashCode();
                if (Days != null)
                    hashCode = hashCode * 59 + Days.GetHashCode();
                if (Required != null)
                    hashCode = hashCode * 59 + Required.GetHashCode();
                if (Modifiable != null)
                    hashCode = hashCode * 59 + Modifiable.GetHashCode();
                return hashCode;
            }
        }
    }
}