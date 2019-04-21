using System;
using Domain.Utils;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Domain.Inventory
{
    public class BottleOfWineAdded : IEvent
    {
        public string Id { get; set; }
        public string Vintage { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}