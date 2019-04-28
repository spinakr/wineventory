using System;
using System.Collections.Generic;
using System.Linq;
using Marten.Events.Projections;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWinesViewProjection : ViewProjection<InventoryWinesView, string>
    {
        public InventoryWinesViewProjection()
        {
            ProjectEvent<FirstBottleOfWineAdded>(ev => "123", (view, @event) => ApplyEvent(view, @event));
            ProjectEvent<BottleOfWineAdded>(ev => "123", (view, @event) => ApplyEvent(view, @event));
        }

        internal void ApplyEvent(InventoryWinesView view, FirstBottleOfWineAdded eevent)
        {
            var wineView = new InventoryWineView();
            wineView.Apply(eevent);
            view.Wines.Add(wineView);
        }

        internal void ApplyEvent(InventoryWinesView view, BottleOfWineAdded eevent)
        {
            var wineView = view.Wines.Single(w => w.Id == eevent.Id);
            wineView.Apply(eevent);
        }
    }
}