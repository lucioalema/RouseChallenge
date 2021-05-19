using System.Collections.Generic;
using MarketAuction.Api.Models;

namespace MarketAuction.Api.DataAccess.Init
{
    public class ScheduleFactory
    {
        internal static IList<Schedule> CreateSchedulesD8T()
        {
            return new List<Schedule>
            {
                new Schedule(2006, 0.311276m, 0.181383m),
                new Schedule(2007, 0.317628m, 0.185085m),
                new Schedule(2008, 0.324111m, 0.188862m),
                new Schedule(2009, 0.330725m, 0.192716m),
                new Schedule(2010, 0.363179m, 0.198498m),
                new Schedule(2011, 0.374074m, 0.206337m),
                new Schedule(2012, 0.431321m, 0.213178m)
            };
        }

        internal static IList<Schedule> CreateSchedules340AJ()
        {
            return new List<Schedule>
            {
                new Schedule(2016, 0.613292m, 0.417468m),
                new Schedule(2017, 0.692965m, 0.473205m),
                new Schedule(2018, 0.980485m, 0.684991m),
                new Schedule(2019, 1.041526m, 0.727636m),
                new Schedule(2020, 1.106366m, 0.772935m)
            };
        }
    }
}
