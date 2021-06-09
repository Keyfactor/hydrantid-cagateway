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
    ///     CertRequestBodySubjectAltNames
    /// </summary>
    [DataContract]
    public class CertRequestBodySubjectAltNames : IEquatable<CertRequestBodySubjectAltNames>, IValidatableObject, ICertRequestBodySubjectAltNames
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertRequestBodySubjectAltNames" /> class.
        /// </summary>
        /// <param name="dNsname">dNSNAME.</param>
        /// <param name="iPaddress">iPADDRESS.</param>
        /// <param name="rFc822Name">rFC822NAME.</param>
        /// <param name="uPn">uPN.</param>
        public CertRequestBodySubjectAltNames(List<string> dNsname = default, List<string> iPaddress = default,
            List<string> rFc822Name = default, List<string> uPn = default)
        {
            Dnsname = dNsname;
            Ipaddress = iPaddress;
            Rfc822Name = rFc822Name;
            Upn = uPn;
        }

        /// <summary>
        ///     Gets or Sets DNSNAME
        /// </summary>
        [DataMember(Name = "DNSNAME", EmitDefaultValue = false)]
        public List<string> Dnsname { get; }

        /// <summary>
        ///     Gets or Sets IPADDRESS
        /// </summary>
        [DataMember(Name = "IPADDRESS", EmitDefaultValue = false)]
        public List<string> Ipaddress { get; }

        /// <summary>
        ///     Gets or Sets RFC822NAME
        /// </summary>
        [DataMember(Name = "RFC822NAME", EmitDefaultValue = false)]
        public List<string> Rfc822Name { get; }

        /// <summary>
        ///     Gets or Sets UPN
        /// </summary>
        [DataMember(Name = "UPN", EmitDefaultValue = false)]
        public List<string> Upn { get; }

        /// <summary>
        ///     Returns true if CertRequestBodySubjectAltNames instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBodySubjectAltNames to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertRequestBodySubjectAltNames input)
        {
            if (input == null)
                return false;

            return
                (
                    Dnsname == input.Dnsname ||
                    Dnsname != null &&
                    input.Dnsname != null &&
                    Dnsname.SequenceEqual(input.Dnsname)
                ) &&
                (
                    Ipaddress == input.Ipaddress ||
                    Ipaddress != null &&
                    input.Ipaddress != null &&
                    Ipaddress.SequenceEqual(input.Ipaddress)
                ) &&
                (
                    Rfc822Name == input.Rfc822Name ||
                    Rfc822Name != null &&
                    input.Rfc822Name != null &&
                    Rfc822Name.SequenceEqual(input.Rfc822Name)
                ) &&
                (
                    Upn == input.Upn ||
                    Upn != null &&
                    input.Upn != null &&
                    Upn.SequenceEqual(input.Upn)
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
            sb.Append("class CertRequestBodySubjectAltNames {\n");
            sb.Append("  DNSNAME: ").Append(Dnsname).Append("\n");
            sb.Append("  IPADDRESS: ").Append(Ipaddress).Append("\n");
            sb.Append("  RFC822NAME: ").Append(Rfc822Name).Append("\n");
            sb.Append("  UPN: ").Append(Upn).Append("\n");
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
            return Equals(input as CertRequestBodySubjectAltNames);
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
                if (Dnsname != null)
                    hashCode = hashCode * 59 + Dnsname.GetHashCode();
                if (Ipaddress != null)
                    hashCode = hashCode * 59 + Ipaddress.GetHashCode();
                if (Rfc822Name != null)
                    hashCode = hashCode * 59 + Rfc822Name.GetHashCode();
                if (Upn != null)
                    hashCode = hashCode * 59 + Upn.GetHashCode();
                return hashCode;
            }
        }
    }
}