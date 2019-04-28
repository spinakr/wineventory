using System;
using System.Collections.Generic;
using Wineventory.Domain.Inventory;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWineView
    {
        public string Id { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public List<Bottle> Bottles { get; set; }

        public void Apply(FirstBottleOfWineAdded eevent)
        {
            Id = eevent.Id;
            Producer = eevent.Producer;
            Name = eevent.Name;
            Fruit = eevent.Fruit;
            Country = eevent.Country;
            ProductType = eevent.ProductType;
            Bottles = new List<Bottle>();
        }

        internal void Apply(BottleOfWineAdded eevent)
        {
            Bottles.Add(new Bottle(eevent.PurchaseDate, eevent.Price, eevent.Vintage));
        }
    }
}