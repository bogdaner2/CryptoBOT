using System.Collections.Generic;

namespace CryptoTrackerAPI.DAL.Entities
{
    public class Crypto:Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public List<CryptoMarket> CryptoMarkets { get; set; }
    }
}
