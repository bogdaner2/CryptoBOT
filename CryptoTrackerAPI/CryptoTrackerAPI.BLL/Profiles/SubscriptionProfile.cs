using AutoMapper;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.Shared.Dtos;

namespace CryptoTrackerAPI.BLL.Profiles
{
    public class SubscriptionProfile:Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, Subscription>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Subscription, SubscriptionDto>();

            CreateMap<SubscriptionDto, Subscription>();
        }
        
    }
}
