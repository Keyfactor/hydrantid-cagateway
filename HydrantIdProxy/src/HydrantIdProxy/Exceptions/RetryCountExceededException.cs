using System;

namespace Keyfactor.HydrantId.Exceptions
{
    public class RetryCountExceededException : Exception
    {
        public RetryCountExceededException(string message) : base(message)
        {
        }
    }
}