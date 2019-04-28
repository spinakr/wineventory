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
            view.Apply(eevent);
        }

        internal void ApplyEvent(InventoryWineView view, BottleOfWineAdded eevent)
        {
            view.Apply(eevent);
        }
    }

}