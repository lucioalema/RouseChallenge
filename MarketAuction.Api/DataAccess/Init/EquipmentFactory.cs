using System.Collections.Generic;
using MarketAuction.Api.Models;

namespace MarketAuction.Api.DataAccess.Init
{
    public class EquipmentFactory
    {
        internal static IList<Equipment> CreateEquipments()
        {
            var e1 = new Equipment(67352, 3, 1);
            var s1 = new SaleDetails(681252, 122, 17, 0.02m, 0.02m);
            s1.AddSchedules(ScheduleFactory.CreateSchedulesD8T());
            e1.AddSaleDetails(s1);

            var e2 = new Equipment(87390, 4, 2);
            var s2 = new SaleDetails(48929, 12, 127, 0.06m, 0.06m);
            s2.AddSchedules(ScheduleFactory.CreateSchedules340AJ());
            e2.AddSaleDetails(s2);
            return new Equipment[] { e1, e2 };
        }
    }
}
