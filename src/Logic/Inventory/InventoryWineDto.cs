using System;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWineDto
    {
        public string VinmonopoletId { get; set; }
        public string ProductType { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Vintage { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
    }
}