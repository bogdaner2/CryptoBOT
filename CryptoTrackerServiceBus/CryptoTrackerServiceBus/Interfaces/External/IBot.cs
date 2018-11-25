using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus.Interfaces.External
{
    public interface IBot
    {
        Task NotifyRateChange();
    }
}
