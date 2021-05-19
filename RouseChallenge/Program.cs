using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RouseChallenge.DataAccess;
using RouseChallenge.DataAccess.Init;

namespace RouseChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader.Seed();
            PrintValues(67352, 2007);
            PrintValues(87964, 2011);
        }

        static void PrintValues(int modelId, int year)
        {
            try
            {
                var values = CalculateValue(modelId, year);
                Console.WriteLine($"Market Value = {values.MarketValue}");
                Console.WriteLine($"Auction Value = {values.AuctionValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static MarketAuctionValues CalculateValue(int modelId, int year)
        {
            using (var context = new MarketAuctionDbContext())
            {
                var equipment = context
                    .Equipments
                    .Include(x => x.SaleDetails)
                    .Include(x => x.Model)
                    .FirstOrDefault(x => x.SaleDetails.Id == modelId);

                if (equipment == null)
                    throw new ArgumentException($"There is no equipment with Id: { modelId }");

                var schedule = context
                    .Schedules
                    .FirstOrDefault(x => x.SaleDetailsId == modelId && x.Year == year);

                if (schedule == null)
                {
                    throw new ArgumentException($"The equipment { equipment.Model.Name } does not have schedule for the year: { year }");
                }

                return new MarketAuctionValues(equipment.SaleDetails.Cost * schedule.MarketRatio, equipment.SaleDetails.Cost * schedule.AuctionRatio);
            }
        }

        private class MarketAuctionValues
        {
            public decimal MarketValue { get; private set; }
            public decimal AuctionValue { get; private set; }
            public MarketAuctionValues(decimal marketValue, decimal auctionValue)
            {
                MarketValue = marketValue;
                AuctionValue = auctionValue;
            }
        }
    }
}
