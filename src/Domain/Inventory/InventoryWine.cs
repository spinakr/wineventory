using System;
using System.Collections.Generic;
using Wineventory.Domain.Utils;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Domain.Inventory
{
    public class InventoryWine : EventSourcedAggregate
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public List<Bottle> Bottles { get; set; }

        public InventoryWine() { }

        public InventoryWine(string vinmonopoletId, string producer, string wineName, string productType, string fruit, string country, string vintage, int price)
        {
            var @event = new FirstBottleOfWineAdded
            {
                Id = vinmonopoletId,
                Producer = producer,
                Name = wineName,
                Fruit = fruit,
                Country = country,
                ProductType = productType,
                Vintage = vintage,
                Price = price,
                PurchaseDate = DateTime.Today
            };

            Apply(@event);
            Append(@event);
        }

        public void AddBottle(string vintage, int price)
        {
            var @event = new BottleOfWineAdded
            {
                Id = Id,
                Vintage = vintage,
                Price = price,
                PurchaseDate = DateTime.Today
            };
            Apply(@event);
            Append(@event);
        }

        public void Apply(FirstBottleOfWineAdded @event)
        {
            Id = @event.Id;
            Producer = @event.Producer;
            Name = @event.Name;
            Fruit = @event.Fruit;
            Country = @event.Country;
            Bottles = new List<Bottle>();
            Bottles.Add(new Bottle(@event.PurchaseDate, @event.Price, @event.Vintage));
        }

        public void Apply(BottleOfWineAdded @event)
        {
            Bottles.Add(new Bottle(@event.PurchaseDate, @event.Price, @event.Vintage));
        }
    }
}
