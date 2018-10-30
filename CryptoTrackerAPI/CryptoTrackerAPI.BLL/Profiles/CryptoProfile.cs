using AutoMapper;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.Shared.Dtos;
using System.Linq;

namespace CryptoTrackerAPI.BLL.Profiles
{
    public class CryptoProfile:Profile
    {
        public CryptoProfile()
        {
            CreateMap<Crypto, Crypto>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Crypto, CryptoDto>()
                .ForMember(d => d.Markets, o => o.MapFrom(s => s.CryptoMarkets.Select(c => c.Market).ToList()));

            CreateMap<CryptoDto, Crypto>();
        }
    }
}
