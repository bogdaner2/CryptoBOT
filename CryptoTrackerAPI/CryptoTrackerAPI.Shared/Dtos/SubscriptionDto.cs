namespace CryptoTrackerAPI.Shared.Dtos
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public MarketDto Market { get; set; }
        public CryptoDto Crypto { get; set; }
    }
}
