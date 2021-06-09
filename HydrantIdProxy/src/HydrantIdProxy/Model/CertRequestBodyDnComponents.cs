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
    ///     CertRequestBodyDnComponents
    /// </summary>
    [DataContract]
    public class CertRequestBodyDnComponents : IEquatable<CertRequestBodyDnComponents>, IValidatableObject, ICertRequestBodyDnComponents
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertRequestBodyDnComponents" /> class.
        /// </summary>
        /// <param name="cN">cN.</param>
        /// <param name="oU">oU.</param>
        /// <param name="o">o.</param>
        /// <param name="l">l.</param>
        /// <param name="sT">sT.</param>
        /// <param name="c">c.</param>
        /// <param name="dC">dC.</param>
        public CertRequestBodyDnComponents(string cN = default, List<string> oU = default, string o = default,
            string l = default, string sT = default, string c = default, List<string> dC = default)
        {
            Cn = cN;
            Ou = oU;
            O = o;
            L = l;
            St = sT;
            C = c;
            Dc = dC;
        }

        /// <summary>
        ///     Gets or Sets CN
        /// </summary>
        [DataMember(Name = "CN", EmitDefaultValue = false)]
        public string Cn { get; }

        /// <summary>
        ///     Gets or Sets OU
        /// </summary>
        [DataMember(Name = "OU", EmitDefaultValue = false)]
        public List<string> Ou { get; }

        /// <summary>
        ///     Gets or Sets O
        /// </summary>
        [DataMember(Name = "O", EmitDefaultValue = false)]
        public string O { get; }

        /// <summary>
        ///     Gets or Sets L
        /// </summary>
        [DataMember(Name = "L", EmitDefaultValue = false)]
        public string L { get; }

        /// <summary>
        ///     Gets or Sets ST
        /// </summary>
        [DataMember(Name = "ST", EmitDefaultValue = false)]
        public string St { get; }

        /// <summary>
        ///     Gets or Sets C
        /// </summary>
        [DataMember(Name = "C", EmitDefaultValue = false)]
        public string C { get; }

        /// <summary>
        ///     Gets or Sets DC
        /// </summary>
        [DataMember(Name = "DC", EmitDefaultValue = false)]
        public List<string> Dc { get; }

        /// <summary>
        ///     Returns true if CertRequestBodyDnComponents instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBodyDnComponents to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertRequestBodyDnComponents input)
        {
            if (input == null)
                return false;

            return
                (
                    Cn == input.Cn ||
                    Cn != null &&
                    Cn.Equals(input.Cn)
                ) &&
                (
                    Ou == input.Ou ||
                    Ou != null &&
                    input.Ou != null &&
                    Ou.SequenceEqual(input.Ou)
                ) &&
                (
                    O == input.O ||
                    O != null &&
                    O.Equals(input.O)
                ) &&
                (
                    L == input.L ||
                    L != null &&
                    L.Equals(input.L)
                ) &&
                (
                    St == input.St ||
                    St != null &&
                    St.Equals(input.St)
                ) &&
                (
                    C == input.C ||
                    C != null &&
                    C.Equals(input.C)
                ) &&
                (
                    Dc == input.Dc ||
                    Dc != null &&
                    input.Dc != null &&
                    Dc.SequenceEqual(input.Dc)
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
            sb.Append("class CertRequestBodyDnComponents {\n");
            sb.Append("  CN: ").Append(Cn).Append("\n");
            sb.Append("  OU: ").Append(Ou).Append("\n");
            sb.Append("  O: ").Append(O).Append("\n");
            sb.Append("  L: ").Append(L).Append("\n");
            sb.Append("  ST: ").Append(St).Append("\n");
            sb.Append("  C: ").Append(C).Append("\n");
            sb.Append("  DC: ").Append(Dc).Append("\n");
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
            return Equals(input as CertRequestBodyDnComponents);
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
                if (Cn != null)
                    hashCode = hashCode * 59 + Cn.GetHashCode();
                if (Ou != null)
                    hashCode = hashCode * 59 + Ou.GetHashCode();
                if (O != null)
                    hashCode = hashCode * 59 + O.GetHashCode();
                if (L != null)
                    hashCode = hashCode * 59 + L.GetHashCode();
                if (St != null)
                    hashCode = hashCode * 59 + St.GetHashCode();
                if (C != null)
                    hashCode = hashCode * 59 + C.GetHashCode();
                if (Dc != null)
                    hashCode = hashCode * 59 + Dc.GetHashCode();
                return hashCode;
            }
        }
    }
}