using System;
using System.Collections.Generic;
using Marten.Events.Projections;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWineViewProjection : ViewProjection<InventoryWineViewProjection.InventoryWineView, string>
    {
        public InventoryWineViewProjection()
        {
            ProjectEvent<FirstBottleOfWineAdded>(ev => ev.Id, (view, @event) => ApplyEvent(view, @event));
            ProjectEvent<BottleOfWineAdded>(ev => ev.Id, (view, @event) => ApplyEvent(view, @event));
        }

        internal void ApplyEvent(InventoryWineView view, FirstBottleOfWineAdded eevent)
        {
            view.Apply(eevent);
        }

        internal void ApplyEvent(InventoryWineView view, BottleOfWineAdded eevent)
        {
            view.Apply(eevent);
        }

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
                Bottles.Add(new Bottle(eevent.PurchaseDate, eevent.Price, eevent.Vintage));
            }

            internal void Apply(BottleOfWineAdded eevent)
            {
                Bottles.Add(new Bottle(eevent.PurchaseDate, eevent.Price, eevent.Vintage));
            }
        }
    }

}