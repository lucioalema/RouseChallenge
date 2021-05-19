namespace MarketAuction.Api.Dtos
{
    public class MarketAuctionValueDto
    {
        public decimal MarketValue { get; set; }
        public decimal AuctionValue { get; set; }

        public MarketAuctionValueDto(decimal marketValue, decimal auctionValue)
        {
            MarketValue = marketValue;
            AuctionValue = auctionValue;
        }
    }
}
