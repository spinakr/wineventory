using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;
using NServiceBus;
using Wineventory.Domain;
using Wineventory.Domain.Vinmonopolet;

namespace Wineventory.MessageEndpoint.Vinmonopolet
{
    public class UpdateVinmonopoletRepositoryCommandHandler : IHandleMessages<UpdateVinmonopoletRepositoryCommand>
    {
        private const string ProductFilePath = "https://www.vinmonopolet.no/medias/sys_master/products/products/hbc/hb0/8834253127710/produkter.csv";
        private HttpClient _httpClient;
        private WineContext _db;

        public UpdateVinmonopoletRepositoryCommandHandler(IHttpClientFactory httpClientFactory, WineContext wineContext)
        {
            _httpClient = httpClientFactory.CreateClient();
            _db = wineContext;
        }

        public async Task Handle(UpdateVinmonopoletRepositoryCommand message, IMessageHandlerContext context)
        {
            var vinmonopoletProducts = await FetchNewProductList();
            await _db.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE public.\"Products\"");
            await _db.Products.AddRangeAsync(vinmonopoletProducts);
            Console.WriteLine("Writing products");
            await _db.SaveChangesAsync();
            Console.WriteLine("Saving...");
        }

        private async Task<IEnumerable<SearchableProduct>> FetchNewProductList()
        {
            var stream = await _httpClient.GetStreamAsync(ProductFilePath);
            var streamReader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1"));
            await streamReader.ReadLineAsync(); //skip header

            var wineInfoEntities = new List<SearchableProduct>();
            while (true)
            {
                var line = await streamReader.ReadLineAsync();
                if (line == null) break;
                wineInfoEntities.Add(MapToWineInfo(line.Split(';')));
            }

            Console.WriteLine($"Fetched new products from vinmonopolet. Number of products: {wineInfoEntities.Count()}");
            return wineInfoEntities;
        }

        private static SearchableProduct MapToWineInfo(string[] wineProps)
        {
            double.TryParse(wineProps[4], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("no-NO"), out var parsedPrice);
            return new SearchableProduct(
                id: wineProps[1],
                name: wineProps[2],
                fruit: wineProps[24],
                vintage: wineProps[23],
                price: parsedPrice,
                country: wineProps[21],
                productType: wineProps[6],
                producer: wineProps[31]);

            //Datotid;Varenummer;Varenavn;Volum;Pris;Literpris;Varetype;Produktutvalg;Butikkategori;Fylde;Friskhet;Garvestoffer;Bitterhet;Sodme(14);
            //Farge;Lukt;Smak;Passertil01;Passertil02;Passertil03;Land(21);Distrikt;Underdistrikt;Argang;Rastoff(25);Metode;Alkohol;Sukker;Syre(29);
            //Lagringsgrad;Produsent;Grossist;Distributor;Emballasjetype;Korktype;Vareurl;Okologisk;Biodynamisk;Fairtrade;Miljosmart_emballasje;
            //Gluten_lav_pa;Kosher
        }

    }
}