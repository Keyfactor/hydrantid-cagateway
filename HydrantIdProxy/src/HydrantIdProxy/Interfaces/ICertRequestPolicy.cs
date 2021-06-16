using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestPolicy
    {
        Guid? Id { get; }
        string Name { get; }

    }
}