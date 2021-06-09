using System;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IPolicy
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets or Sets ApiId
        /// </summary>
        int? ApiId { get; }

        /// <summary>
        ///     Gets or Sets Details
        /// </summary>
        PolicyDetails Details { get; }

        /// <summary>
        ///     Gets or Sets Enabled
        /// </summary>
        PolicyEnabled Enabled { get; }

        /// <summary>
        ///     Gets or Sets OrganizationId
        /// </summary>
        Guid? OrganizationId { get; }

        /// <summary>
        ///     Gets or Sets CertificateAuthorityId
        /// </summary>
        Guid? CertificateAuthorityId { get; }

        /// <summary>
        ///     Returns true if Policy instances are equal
        /// </summary>
        /// <param name="input">Instance of Policy to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(Policy input);

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        string ToString();

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        string GetJson();

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(object input);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        int GetHashCode();
    }
}