namespace CryptoTrackerAPI.Shared.Dtos
{
    public class CryptoMarketDto
    {
        public int Id { get; set; }
        public MarketDto Market { get; set; }
        public CryptoDto Crypto { get; set; }
    }
}
