using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IHawkCredential
    {
        string Id { get; }
        string Key { get; }
        string Comments { get; }
        DateTime? LastUsed { get; }
        DateTime? CreatedAt { get; }
        DateTime? UpdatedAt { get; }

    }
}