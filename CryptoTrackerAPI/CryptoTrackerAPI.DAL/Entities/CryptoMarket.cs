namespace CryptoTrackerAPI.DAL.Entities
{
    public class CryptoMarket:Entity
    {
        public int MarketId { get; set; }
        public Market Market { get; set; }

        public int CryptoId { get; set; }
        public Crypto Crypto { get; set; }
    }
}
