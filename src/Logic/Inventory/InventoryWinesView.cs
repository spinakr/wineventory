using System;
using System.Collections.Generic;
using Wineventory.Domain.Inventory;

namespace Wineventory.Logic.Inventory
{
    public class InventoryWinesView
    {
        public InventoryWinesView()
        {
            Wines = new List<InventoryWineView>();
        }

        public string Id { get; set; }
        public List<InventoryWineView> Wines { get; set; }
    }
}