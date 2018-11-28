using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTrackerServiceBus.Interfaces
{
    public interface ILogger
    {
        void Log(string message);

        void Warning(string message);

        void Error(string message);

        void Debug(string message);

        void Success(string message);
    }
}
