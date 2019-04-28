using System;
using Domain.Utils;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Domain.Inventory
{
    public class FirstBottleOfWineAdded : IEvent
    {
        public string Id { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
        public string Vintage { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}