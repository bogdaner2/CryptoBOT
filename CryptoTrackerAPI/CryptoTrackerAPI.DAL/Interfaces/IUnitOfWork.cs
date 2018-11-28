using System;
using System.Threading.Tasks;

namespace CryptoTrackerAPI.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        Task<bool> SaveAsync();

        ISubscriptionRepository SubscriptionRepository { get; }
        IMarketRepository MarketRepository { get; }
        ICryptoRepository CryptoRepository { get; }
    }
}
