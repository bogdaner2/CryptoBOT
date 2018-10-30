using CryptoTrackerAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrackerAPI.DAL.Data
{
    public static class CryptoTrackerDbSeed
    { 
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crypto>().HasData(
               new Crypto()
               {
                   Id = 1,
                   Name = "BitCoin",
                   Code = "Btc"
               });

            modelBuilder.Entity<Market>().HasData(
                new Market()
                {
                    Id = 1,
                    Name = "MARKETPLACE",
                    Uri = "google.com",
                });

            modelBuilder.Entity<Subscription>().HasData(new Subscription()
            {
                Id = 1,
                CryptoId = 1,
                UserId = 1,
                MarketId = 1
            });

            modelBuilder.Entity<CryptoMarket>().HasData(new CryptoMarket()
            {
                Id = 1,
                CryptoId = 1,
                MarketId = 1
            });
        }
    }
}
