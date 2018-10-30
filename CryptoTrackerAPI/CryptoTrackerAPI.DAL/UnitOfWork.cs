using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Interfaces;
using CryptoTrackerAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrackerAPI.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(CryptoTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private CryptoTrackerDbContext _context;
        private IMapper _mapper;
        private ISubscriptionRepository _subscriptionRepository;
        private ICryptoRepository _cryptoRepository;
        private IMarketRepository _marketRepository;
        private ICryptoMarketRepository _cryptoMarketRepository;

        public ISubscriptionRepository SubscriptionRepository 
            => _subscriptionRepository ?? (_subscriptionRepository = 
                                            new SubscriptionRepository(_context, _mapper));

        public ICryptoRepository CryptoRepository
           => _cryptoRepository ?? (_cryptoRepository =
                                           new CryptoRepository(_context, _mapper));

        public IMarketRepository MarketRepository
           => _marketRepository ?? (_marketRepository =
                                           new MarketRepository(_context, _mapper));

        public ICryptoMarketRepository CryptoMarketRepository
           => _cryptoMarketRepository ?? (_cryptoMarketRepository =
                                           new CryptoMarketRepository(_context, _mapper));

        public async Task<bool> SaveAsync()
        {
            try
            {
                var changes = _context.ChangeTracker.Entries().Count(
                    p => p.State == EntityState.Modified 
                      || p.State == EntityState.Deleted
                      || p.State == EntityState.Added);

                if (changes == 0) return true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
