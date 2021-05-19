using System.Linq;
using MarketAuction.Api.DataAccess.Repositories;

namespace MarketAuction.Api.DataAccess.Init
{
    public class DataLoader
    {
        private readonly MarketAuctionDbContext dbContext;

        public DataLoader(MarketAuctionDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            if (dbContext.Equipments.Any() || dbContext.Categories.Any() || dbContext.Makes.Any() || dbContext.Models.Any())
            {
                return;
            }

            var categories = CategoryFactory.CreateCategories();
            var subCategory = CategoryFactory.CreateSubCategories();
            var makes = MakeFactory.CreateMakes();
            var models = ModelFactory.CreateModels();
            var equipments = EquipmentFactory.CreateEquipments();

            dbContext.Categories.AddRange(categories);
            dbContext.Categories.AddRange(subCategory);
            dbContext.Makes.AddRange(makes);
            dbContext.Models.AddRange(models);
            dbContext.Equipments.AddRange(equipments);

            dbContext.SaveChanges();
        }
    }
}
