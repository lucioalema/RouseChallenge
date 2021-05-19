using System.Collections.Generic;
using MarketAuction.Api.Models;

namespace MarketAuction.Api.DataAccess.Init
{
    public class MakeFactory
    {
        internal static IList<Make> CreateMakes()
        {
            return new List<Make>
            {
                new Make(1, "Caterpillar"),
                new Make(2, "JLG")
            };
        }
    }
}
