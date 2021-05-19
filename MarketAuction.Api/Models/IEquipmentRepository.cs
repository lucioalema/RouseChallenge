using System.Threading.Tasks;

namespace MarketAuction.Api.Models
{
    public interface IEquipmentRepository
    {
        Task<Equipment> GetById(int id);
    }
}
