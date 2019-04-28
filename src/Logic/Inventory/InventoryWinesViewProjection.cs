using System;
using System.Collections.Generic;
using System.Linq;
using Marten.Events.Projections;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWinesViewProjection : ViewProjection<InventoryWinesViewProjection.InventoryWinesView, string>
    {
        public InventoryWinesViewProjection()
        {
            ProjectEvent<FirstBottleOfWineAdded>(ev => "123", (view, @event) => ApplyEvent(view, @event));
            ProjectEvent<BottleOfWineAdded>(ev => "123", (view, @event) => ApplyEvent(view, @event));
        }

        internal void ApplyEvent(InventoryWinesView view, FirstBottleOfWineAdded eevent)
        {
            view.Wines.Add(new ViewWine
            {
                Id = eevent.Id,
                Producer = eevent.Producer,
                Name = eevent.Name,
                Fruit = eevent.Fruit,
                Country = eevent.Country,
                ProductType = eevent.ProductType,
                Vintage = eevent.Vintage,
                Price = eevent.Price,
                Count = 1
            });
        }

        internal void ApplyEvent(InventoryWinesView view, BottleOfWineAdded eevent)
        {
            var viewWine = view.Wines.Single(w => w.Id == eevent.Id);
            viewWine.Count++;
            viewWine.Price = Math.Max(viewWine.Price, eevent.Price);
        }

        public class InventoryWinesView
        {
            public InventoryWinesView()
            {
                Wines = new List<ViewWine>();
            }
            public string Id { get; set; }
            public List<ViewWine> Wines { get; set; }
        }

        public class ViewWine
        {
            public string Id { get; set; }
            public string Producer { get; set; }
            public string Name { get; set; }
            public string ProductType { get; set; }
            public string Fruit { get; set; }
            public string Country { get; set; }
            public int Price { get; set; }
            public string Vintage { get; set; }
            public int Count { get; set; }
        }
    }

}