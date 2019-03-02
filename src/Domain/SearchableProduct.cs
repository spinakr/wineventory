namespace Wineventory.Domain
{
    public class SearchableProduct
    {
        public string VinmonopoletId { get; set; }
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Vintage { get; set; }

        //Datotid;Varenummer;Varenavn;Volum;Pris;Literpris;Varetype;Produktutvalg;Butikkategori;Fylde;Friskhet;Garvestoffer;Bitterhet;Sodme(14);
        //Farge;Lukt;Smak;Passertil01;Passertil02;Passertil03;Land(21);Distrikt;Underdistrikt;Argang;Rastoff(25);Metode;Alkohol;Sukker;Syre(29);
        //Lagringsgrad;Produsent;Grossist;Distributor;Emballasjetype;Korktype;Vareurl;Okologisk;Biodynamisk;Fairtrade;Miljosmart_emballasje;
        //Gluten_lav_pa;Kosher
    }
}