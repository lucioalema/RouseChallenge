using System;
using System.Threading.Tasks;
using MarketAuction.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAuction.Api.DataAccess.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly MarketAuctionDbContext _marketAuctionDbContext;

        public ScheduleRepository(MarketAuctionDbContext marketAuctionDbContext)
        {
            _marketAuctionDbContext = marketAuctionDbContext ?? throw new ArgumentNullException(nameof(marketAuctionDbContext));
        }

        public async Task<Schedule> GetByYearAndSaleDetailsId(int year, int saleDetailsId)
        {
            return await _marketAuctionDbContext.Schedules.FirstOrDefaultAsync(x => x.SaleDetailsId == saleDetailsId && x.Year == year);
        }
    }
}
