using System;
using System.ComponentModel.DataAnnotations;

namespace MarketAuction.Api.Models
{
    public class Schedule
    {
        [Key]
        public int Year { get; private set; }
        [Required]
        public decimal MarketRatio { get; private set; }
        [Required]
        public decimal AuctionRatio { get; private set; }

        public int SaleDetailsId { get; private set; }
        public SaleDetails SaleDetails { get; private set; }

        public Schedule(int year, decimal marketRatio, decimal auctionRatio)
        {
            Year = year > 1900 ? year : throw new ArgumentException();
            MarketRatio = marketRatio >= 0 ? marketRatio : throw new ArgumentException();
            AuctionRatio = auctionRatio >= 0 ? auctionRatio : throw new ArgumentException();
        }
    }
}
