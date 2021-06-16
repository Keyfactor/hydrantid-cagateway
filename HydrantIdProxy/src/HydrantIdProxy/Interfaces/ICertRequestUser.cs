using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestUser
    {
        Guid? Id { get; }
        string FirstName { get; }
        string LastName { get; }

    }
}