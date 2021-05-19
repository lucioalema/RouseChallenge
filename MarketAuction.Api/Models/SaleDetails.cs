using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAuction.Api.Models
{
    public class SaleDetails
    {
        [Key, ForeignKey("Equipment")]
        public int Id { get; private set; }
        [Required]
        public decimal Cost { get; private set; }
        [Required]
        public int RetailSaleCount { get; private set; }
        [Required]
        public int AuctionSaleCount { get; private set; }
        [Required]
        public decimal DefaultMarketRatio { get; private set; }
        [Required]
        public decimal DefaultAuctionRatio { get; private set; }

        public Equipment Equipment { get; private set; }
        public IList<Schedule> Schedules { get; private set; }

        public SaleDetails(decimal cost, int retailSaleCount, int auctionSaleCount, decimal defaultMarketRatio, decimal defaultAuctionRatio)
        {
            Cost = cost >= 0 ? cost : throw new ArgumentException();
            RetailSaleCount = retailSaleCount >= 0 ? retailSaleCount : throw new ArgumentException();
            AuctionSaleCount = auctionSaleCount >= 0 ? auctionSaleCount : throw new ArgumentException();
            DefaultMarketRatio = defaultMarketRatio >= 0 ? defaultMarketRatio : throw new ArgumentException();
            DefaultAuctionRatio = defaultAuctionRatio >= 0 ? defaultAuctionRatio : throw new ArgumentException();
            Schedules = new List<Schedule>();
        }

        public void AddSchedule(Schedule schedule)
        {
            Schedules.Add(schedule);
        }

        public void AddSchedules(IList<Schedule> schedules)
        {
            foreach (var s in schedules)
                Schedules.Add(s);
        }
    }
}
