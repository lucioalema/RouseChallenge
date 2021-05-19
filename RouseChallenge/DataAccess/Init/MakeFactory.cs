using System.Collections.Generic;
using RouseChallenge.Domain;

namespace RouseChallenge.DataAccess.Init
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
