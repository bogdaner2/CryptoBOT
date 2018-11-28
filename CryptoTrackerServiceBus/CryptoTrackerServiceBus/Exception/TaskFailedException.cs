using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTrackerServiceBus.Exception
{
    class TaskFailedException : SystemException
    {
        public TaskFailedException(string message) : base(message)
        {
        }
    }
}
