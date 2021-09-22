using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestPolicy
    {
        Guid? Id { get;set; }
        string Name { get;set; }

    }
}