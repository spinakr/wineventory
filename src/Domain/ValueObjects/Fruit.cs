using System.Collections.Generic;
using System.Linq;

namespace Wineventory.Domain.ValueObjects
{
    public class Fruit
    {
        private Fruit(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        private static List<Fruit> All = new List<Fruit> { CabernetSavignon, Syrah };

        public string Name { get; }
        public Country Country { get; }

        public static Fruit CabernetSavignon = new Fruit("Cabernet Savignon", Country.France);
        public static Fruit Syrah = new Fruit("Syrah", Country.France);

        public static Fruit Parse(string fruitString)
        {
            return All.SingleOrDefault(x => x.Name == fruitString) ?? new Fruit(fruitString, Country.Unknown);
        }
    }
}