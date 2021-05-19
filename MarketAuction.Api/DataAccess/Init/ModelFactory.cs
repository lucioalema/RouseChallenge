using System.Collections.Generic;
using MarketAuction.Api.Models;

namespace MarketAuction.Api.DataAccess.Init
{
    public class ModelFactory
    {
        internal static IList<Model> CreateModels()
        {
            return new List<Model>
            {
                new Model(1, "D8T", 1),
                new Model(2, "340AJ", 2)
            };
        }
    }
}
