using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.DAL.Interfaces;

namespace CryptoTrackerAPI.DAL.Repositories
{
    public class CryptoRepository: GenericRepository<Crypto>, ICryptoRepository
    {
        public CryptoRepository(CryptoTrackerDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
