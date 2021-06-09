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
    ///     PolicyEnabled
    /// </summary>
    [DataContract]
    public class PolicyEnabled : IEquatable<PolicyEnabled>, IValidatableObject, IPolicyEnabled
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolicyEnabled" /> class.
        /// </summary>
        /// <param name="ui">ui.</param>
        /// <param name="rest">rest.</param>
        /// <param name="acme">acme.</param>
        /// <param name="scep">scep.</param>
        /// <param name="est">est.</param>
        public PolicyEnabled(bool? ui = default, bool? rest = default, bool? acme = default, bool? scep = default,
            bool? est = default)
        {
            Ui = ui;
            Rest = rest;
            Acme = acme;
            Scep = scep;
            Est = est;
        }

        /// <summary>
        ///     Gets or Sets Ui
        /// </summary>
        [DataMember(Name = "ui", EmitDefaultValue = false)]
        public bool? Ui { get; }

        /// <summary>
        ///     Gets or Sets Rest
        /// </summary>
        [DataMember(Name = "rest", EmitDefaultValue = false)]
        public bool? Rest { get; }

        /// <summary>
        ///     Gets or Sets Acme
        /// </summary>
        [DataMember(Name = "acme", EmitDefaultValue = false)]
        public bool? Acme { get; }

        /// <summary>
        ///     Gets or Sets Scep
        /// </summary>
        [DataMember(Name = "scep", EmitDefaultValue = false)]
        public bool? Scep { get; }

        /// <summary>
        ///     Gets or Sets Est
        /// </summary>
        [DataMember(Name = "est", EmitDefaultValue = false)]
        public bool? Est { get; }

        /// <summary>
        ///     Returns true if PolicyEnabled instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyEnabled to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyEnabled input)
        {
            if (input == null)
                return false;

            return
                (
                    Ui == input.Ui ||
                    Ui != null &&
                    Ui.Equals(input.Ui)
                ) &&
                (
                    Rest == input.Rest ||
                    Rest != null &&
                    Rest.Equals(input.Rest)
                ) &&
                (
                    Acme == input.Acme ||
                    Acme != null &&
                    Acme.Equals(input.Acme)
                ) &&
                (
                    Scep == input.Scep ||
                    Scep != null &&
                    Scep.Equals(input.Scep)
                ) &&
                (
                    Est == input.Est ||
                    Est != null &&
                    Est.Equals(input.Est)
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
            sb.Append("class PolicyEnabled {\n");
            sb.Append("  Ui: ").Append(Ui).Append("\n");
            sb.Append("  Rest: ").Append(Rest).Append("\n");
            sb.Append("  Acme: ").Append(Acme).Append("\n");
            sb.Append("  Scep: ").Append(Scep).Append("\n");
            sb.Append("  Est: ").Append(Est).Append("\n");
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
            return Equals(input as PolicyEnabled);
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
                if (Ui != null)
                    hashCode = hashCode * 59 + Ui.GetHashCode();
                if (Rest != null)
                    hashCode = hashCode * 59 + Rest.GetHashCode();
                if (Acme != null)
                    hashCode = hashCode * 59 + Acme.GetHashCode();
                if (Scep != null)
                    hashCode = hashCode * 59 + Scep.GetHashCode();
                if (Est != null)
                    hashCode = hashCode * 59 + Est.GetHashCode();
                return hashCode;
            }
        }
    }
}