using System.Threading.Tasks;

namespace MarketAuction.Api.Models
{
    public interface IScheduleRepository
    {
        Task<Schedule> GetByYearAndSaleDetailsId(int year, int saleDetailsId);
    }
}
