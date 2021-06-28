using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificateUser
    {
        Guid? Id { get;set; }
        string Email { get;set; }

    }
}