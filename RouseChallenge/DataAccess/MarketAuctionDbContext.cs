using RouseChallenge.Domain;
using Microsoft.EntityFrameworkCore;

namespace RouseChallenge.DataAccess
{
    public class MarketAuctionDbContext: DbContext
    {

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
