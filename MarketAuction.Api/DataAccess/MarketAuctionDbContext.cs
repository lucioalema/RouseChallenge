using MarketAuction.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAuction.Api.DataAccess
{
    public class MarketAuctionDbContext : DbContext
    {
        public MarketAuctionDbContext(DbContextOptions<MarketAuctionDbContext> options) : base(options)
        { }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MarketAuction");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}