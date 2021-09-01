using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestUser
    {
        Guid? Id { get;set; }
        string FirstName { get;set; }
        string LastName { get;set; }

    }
}