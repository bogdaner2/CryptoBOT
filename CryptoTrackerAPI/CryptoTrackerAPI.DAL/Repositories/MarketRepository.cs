using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.DAL.Interfaces;

namespace CryptoTrackerAPI.DAL.Repositories
{
    public class MarketRepository: GenericRepository<Market>, IMarketRepository
    {
        public MarketRepository(CryptoTrackerDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
