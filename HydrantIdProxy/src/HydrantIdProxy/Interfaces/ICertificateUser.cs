using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificateUser
    {
        Guid? Id { get; }
        string Email { get; }

    }
}