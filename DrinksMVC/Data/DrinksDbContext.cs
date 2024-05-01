using DrinksMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrinksMVC.Data
{
    public class DrinksDbContext : DbContext
    {
        public DbSet<ListDrinks> Drinks { get; set; }
        public DbSet<WendingMachine> WendingMachine { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinStorage> Storage { get; set; }
        public DrinksDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WendingMachine>()
                .HasKey(a => a.Drinks)
                .WithOne(c => c.WendingMachine)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
