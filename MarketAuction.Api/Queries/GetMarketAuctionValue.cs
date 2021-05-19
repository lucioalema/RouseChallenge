using MarketAuction.Api.Dtos;
using MediatR;

namespace MarketAuction.Api.Queries
{
    public class GetMarketAuctionValue : IRequest<MarketAuctionValueDto>
    {
        public int EquipmentId { get; set; }
        public int Year { get; set; }
    }
}
