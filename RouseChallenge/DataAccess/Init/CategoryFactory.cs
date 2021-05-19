using System.Collections.Generic;
using RouseChallenge.Domain;

namespace RouseChallenge.DataAccess.Init
{
    public class CategoryFactory
    {
        internal static IList<Category> CreateCategories()
        {
            return new List<Category>
            {
                new Category(1, "Earthmoving Equipment"),
                new Category(2, "Aerial Equipment")
            };
        }

        internal static IList<Category> CreateSubCategories()
        {
            return new List<Category>
            {
                new Category(3, "Dozers", 1),
                new Category(4, "Boom Lifts", 2)
            };
        }
    }
}
