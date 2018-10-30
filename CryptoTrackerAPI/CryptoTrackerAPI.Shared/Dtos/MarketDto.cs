using System.Collections.Generic;

namespace CryptoTrackerAPI.Shared.Dtos
{
    public class MarketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public List<CryptoDto> Cryptos { get; set; }
    }
}
