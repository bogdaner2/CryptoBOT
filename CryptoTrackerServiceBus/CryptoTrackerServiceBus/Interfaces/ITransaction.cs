using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus.Interfaces
{
    public interface ITransaction
    {
        int Retries { get; set; }
        void Run();
        ITransaction AddAction(Action action);
    }
}
