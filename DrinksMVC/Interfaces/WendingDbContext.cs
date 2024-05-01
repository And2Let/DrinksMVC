using DrinksMVC.Data;
using DrinksMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrinksMVC.Interfaces
{
    public class WendingDbContext : DbContext
    {
        public DbSet<ListDrinks> Drinks { get; set; }
        public DbSet<WendingMachine> WendingMachine { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinStorage> Storages { get; set; }

        public WendingDbContext(DbContextOptions<WendingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WendingMachine>()
                .HasMany(a => a.Drinks)
                .WithOne(c => c.WendingMachine)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
