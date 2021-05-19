using System;
using System.Threading.Tasks;
using MarketAuction.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAuction.Api.DataAccess.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly MarketAuctionDbContext _marketAuctionDbContext;

        public EquipmentRepository(MarketAuctionDbContext marketAuctionDbContext)
        {
            _marketAuctionDbContext = marketAuctionDbContext ?? throw new ArgumentNullException(nameof(marketAuctionDbContext));
        }

        public async Task<Equipment> GetById(int id)
        {
            return await _marketAuctionDbContext.Equipments.Include(x => x.SaleDetails).Include(x => x.Model).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
