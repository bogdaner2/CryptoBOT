using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.DAL.Interfaces;

namespace CryptoTrackerAPI.DAL.Repositories
{
    public class CryptoMarketRepository: GenericRepository<CryptoMarket>, ICryptoMarketRepository
    {
        public CryptoMarketRepository(CryptoTrackerDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
