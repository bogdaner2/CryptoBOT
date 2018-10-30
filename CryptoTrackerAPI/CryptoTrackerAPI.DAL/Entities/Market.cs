using System.Collections.Generic;

namespace CryptoTrackerAPI.DAL.Entities
{
    public class Market: Entity
    {
        public string Name { get; set; }

        public string Uri { get; set; }

        public List<CryptoMarket> CryptoMarkets { get; set; }
    }
}
