using System;

namespace Wineventory.Domain.Inventory
{
    public class Bottle
    {
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Vintage { get; }

    }
}