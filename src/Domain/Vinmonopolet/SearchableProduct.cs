using System;

namespace Wineventory.Domain.Vinmonopolet
{
    public class SearchableProduct
    {
        public SearchableProduct() { }

        public SearchableProduct(string id, string name, string fruit, string vintage, double price, string country, string productType, string producer)
        {
            Id = id;
            Name = name;
            Fruit = fruit;
            Vintage = vintage;
            Price = price;
            Country = country;
            ProductType = productType;
            Producer = producer;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Vintage { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public string ProductType { get; set; }
        public string Producer { get; set; }

        //Datotid;Varenummer;Varenavn;Volum;Pris;Literpris;Varetype;Produktutvalg;Butikkategori;Fylde;Friskhet;Garvestoffer;Bitterhet;Sodme(14);
        //Farge;Lukt;Smak;Passertil01;Passertil02;Passertil03;Land(21);Distrikt;Underdistrikt;Argang;Rastoff(25);Metode;Alkohol;Sukker;Syre(29);
        //Lagringsgrad;Produsent;Grossist;Distributor;Emballasjetype;Korktype;Vareurl;Okologisk;Biodynamisk;Fairtrade;Miljosmart_emballasje;
        //Gluten_lav_pa;Kosher
    }
}