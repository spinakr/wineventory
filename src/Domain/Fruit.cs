namespace Wineventory.Domain
{
    public class Fruit
    {
        private Fruit(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        public string Name { get; }
        public Country Country { get; }

        public static Fruit CabernetSavignon = new Fruit("Cabernet Savignon", Country.France);
        public static Fruit Syrah = new Fruit("Syrah", Country.France);
    }
}