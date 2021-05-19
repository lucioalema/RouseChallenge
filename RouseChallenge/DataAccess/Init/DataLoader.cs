using System.Linq;

namespace RouseChallenge.DataAccess.Init
{
    public static class DataLoader
    {
        public static void Seed()
        {
            using (var dbContext = new MarketAuctionDbContext())
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
}
