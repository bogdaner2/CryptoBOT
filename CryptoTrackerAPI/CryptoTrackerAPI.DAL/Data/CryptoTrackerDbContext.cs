using CryptoTrackerAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrackerAPI.DAL.Data
{
    public class CryptoTrackerDbContext:DbContext
    {
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public CryptoTrackerDbContext(DbContextOptions<CryptoTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CryptoMarket>()
                        .HasKey(cm => new { cm.CryptoId, cm.MarketId });

            modelBuilder.Seed();
        }
    }
}
