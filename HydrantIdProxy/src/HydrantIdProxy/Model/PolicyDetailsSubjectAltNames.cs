using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     PolicyDetailsSubjectAltNames
    /// </summary>
    [DataContract]
    public class PolicyDetailsSubjectAltNames : IEquatable<PolicyDetailsSubjectAltNames>, IValidatableObject, IPolicyDetailsSubjectAltNames
    {
        /// <summary>
        ///     Defines Tag
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TagEnum
        {
            /// <summary>
            ///     Enum DNSNAME for value: DNSNAME
            /// </summary>
            [EnumMember(Value = "DNSNAME")] DnsName = 1,

            /// <summary>
            ///     Enum IPADDRESS for value: IPADDRESS
            /// </summary>
            [EnumMember(Value = "IPADDRESS")] IpAddress = 2,

            /// <summary>
            ///     Enum RFC822NAME for value: RFC822NAME
            /// </summary>
            [EnumMember(Value = "RFC822NAME")] Rfc822Name = 3,

            /// <summary>
            ///     Enum UPN for value: UPN
            /// </summary>
            [EnumMember(Value = "UPN")] Upn = 4
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolicyDetailsSubjectAltNames" /> class.
        /// </summary>
        /// <param name="tag">tag.</param>
        /// <param name="label">label.</param>
        /// <param name="required">required.</param>
        /// <param name="modifiable">modifiable.</param>
        /// <param name="defaultValue">defaultValue.</param>
        public PolicyDetailsSubjectAltNames(TagEnum? tag = default, string label = default, bool? required = default,
            bool? modifiable = default, string defaultValue = default)
        {
            Tag = tag;
            Label = label;
            Required = required;
            Modifiable = modifiable;
            DefaultValue = defaultValue;
        }

        /// <summary>
        ///     Gets or Sets Tag
        /// </summary>
        [DataMember(Name = "tag", EmitDefaultValue = false)]
        public TagEnum? Tag { get; }


        /// <summary>
        ///     Gets or Sets Label
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; }

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
        ///     Gets or Sets DefaultValue
        /// </summary>
        [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
        public string DefaultValue { get; }

        /// <summary>
        ///     Returns true if PolicyDetailsSubjectAltNames instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetailsSubjectAltNames to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyDetailsSubjectAltNames input)
        {
            if (input == null)
                return false;

            return
                (
                    Tag == input.Tag ||
                    Tag != null &&
                    Tag.Equals(input.Tag)
                ) &&
                (
                    Label == input.Label ||
                    Label != null &&
                    Label.Equals(input.Label)
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
                ) &&
                (
                    DefaultValue == input.DefaultValue ||
                    DefaultValue != null &&
                    DefaultValue.Equals(input.DefaultValue)
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
            sb.Append("class PolicyDetailsSubjectAltNames {\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Modifiable: ").Append(Modifiable).Append("\n");
            sb.Append("  DefaultValue: ").Append(DefaultValue).Append("\n");
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
            return Equals(input as PolicyDetailsSubjectAltNames);
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
                if (Tag != null)
                    hashCode = hashCode * 59 + Tag.GetHashCode();
                if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                if (Required != null)
                    hashCode = hashCode * 59 + Required.GetHashCode();
                if (Modifiable != null)
                    hashCode = hashCode * 59 + Modifiable.GetHashCode();
                if (DefaultValue != null)
                    hashCode = hashCode * 59 + DefaultValue.GetHashCode();
                return hashCode;
            }
        }
    }
}