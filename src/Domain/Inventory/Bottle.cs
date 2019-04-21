using System;

namespace Wineventory.Domain.Inventory
{
    public class Bottle
    {
        public Bottle(DateTime purchaseDate, int price, string vintage)
        {
            PurchaseDate = purchaseDate;
            Price = price;
            Vintage = vintage;


        }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Vintage { get; }

    }
}