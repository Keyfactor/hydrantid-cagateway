using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     GetCertificatesResponse
    /// </summary>
    [DataContract]
    public class CertificatesResponse : IEquatable<CertificatesResponse>, IValidatableObject, ICertificatesResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesResponse" /> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="items">items.</param>
        public CertificatesResponse(int? count = default, List<CertificatesResponseItem> items = default)
        {
            Count = count;
            Items = items;
        }

        /// <summary>
        ///     Gets or Sets Count
        /// </summary>
        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int? Count { get; }

        /// <summary>
        ///     Gets or Sets Items
        /// </summary>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<CertificatesResponseItem> Items { get; }

        /// <summary>
        ///     Returns true if GetCertificatesResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCertificatesResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertificatesResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    Count == input.Count ||
                    Count != null &&
                    Count.Equals(input.Count)
                ) &&
                (
                    Items == input.Items ||
                    Items != null &&
                    input.Items != null &&
                    Items.SequenceEqual(input.Items)
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
            sb.Append("class GetCertificatesResponse {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
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
            return Equals(input as CertificatesResponse);
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
                if (Count != null)
                    hashCode = hashCode * 59 + Count.GetHashCode();
                if (Items != null)
                    hashCode = hashCode * 59 + Items.GetHashCode();
                return hashCode;
            }
        }
    }
}