using System;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IHawkCredential
    {
        string Id { get;set; }
        string Key { get;set; }
        string Comments { get;set; }
        DateTime? LastUsed { get;set; }
        DateTime? CreatedAt { get;set; }
        DateTime? UpdatedAt { get;set; }

    }
}