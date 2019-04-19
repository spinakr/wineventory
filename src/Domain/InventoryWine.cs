using System;
using Wineventory.Domain.ValueObjects;

namespace Wineventory.Domain
{
    public class InventoryWine
    {
        public string VinmonopoletId { get; set; }
        public string Producer { get; }
        public string WineName { get; }
        public string Vintage { get; }
        public Fruit Fruit { get; set; }
        public Country Country { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }

        //Datotid;Varenummer;Varenavn;Volum;Pris;Literpris;Varetype;Produktutvalg;Butikkategori;Fylde;Friskhet;Garvestoffer;Bitterhet;Sodme(14);
        //Farge;Lukt;Smak;Passertil01;Passertil02;Passertil03;Land(21);Distrikt;Underdistrikt;Argang;Rastoff(25);Metode;Alkohol;Sukker;Syre(29);
        //Lagringsgrad;Produsent;Grossist;Distributor;Emballasjetype;Korktype;Vareurl;Okologisk;Biodynamisk;Fairtrade;Miljosmart_emballasje;
        //Gluten_lav_pa;Kosher
    }
}
