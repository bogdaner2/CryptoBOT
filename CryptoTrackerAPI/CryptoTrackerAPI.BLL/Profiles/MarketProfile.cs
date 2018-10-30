using AutoMapper;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.Shared.Dtos;
using System.Linq;

namespace CryptoTrackerAPI.BLL.Profiles
{
    public class MarketProfile:Profile
    {
        public MarketProfile()
        {
            CreateMap<Market, Market>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Market, MarketDto>()
                .ForMember(d => d.Cryptos, o => o.MapFrom(s => s.CryptoMarkets.Select(c => c.Crypto).ToList()));

            CreateMap<MarketDto, Market>();
        }
    }
}
