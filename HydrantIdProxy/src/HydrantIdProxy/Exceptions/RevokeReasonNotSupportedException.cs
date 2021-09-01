using System;

namespace Keyfactor.HydrantId.Exceptions
{
    public class RevokeReasonNotSupportedException : Exception
    {
        public RevokeReasonNotSupportedException(string message) : base(message)
        {
        }
    }
}