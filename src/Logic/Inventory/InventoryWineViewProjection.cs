using System;
using System.Collections.Generic;
using Marten.Events.Projections;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWineViewProjection : ViewProjection<InventoryWineView, string>
    {
        public InventoryWineViewProjection()
        {
            ProjectEvent<FirstBottleOfWineAdded>(ev => ev.Id, (view, @event) => ApplyEvent(view, @event));
            ProjectEvent<BottleOfWineAdded>(ev => ev.Id, (view, @event) => ApplyEvent(view, @event));
        }

        internal void ApplyEvent(InventoryWineView view, FirstBottleOfWineAdded eevent)
        {
            view.Id = eevent.Id;
            view.Producer = eevent.Producer;
            view.Name = eevent.Name;
            view.Fruit = eevent.Fruit;
            view.Country = eevent.Country;
            view.ProductType = eevent.ProductType;
            view.Bottles = new List<Bottle>();
        }

        internal void ApplyEvent(InventoryWineView view, BottleOfWineAdded eevent)
        {
            view.Bottles.Add(new Bottle(eevent.PurchaseDate, eevent.Price, eevent.Vintage));
        }
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
    }
}