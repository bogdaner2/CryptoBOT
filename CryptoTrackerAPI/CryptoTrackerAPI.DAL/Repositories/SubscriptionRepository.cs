using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.DAL.Interfaces;

namespace CryptoTrackerAPI.DAL.Repositories
{
    public class SubscriptionRepository: GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(CryptoTrackerDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
