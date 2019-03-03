using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NServiceBus;
using Wineventory.Domain;

namespace Wineventory.MessageEndpoint.Vinmonopolet
{
    public class UpdateVinmonopoletRepositoryCommandHandler : IHandleMessages<UpdateVinmonopoletRepositoryCommand>
    {
        private const string ProductFilePath = "https://www.vinmonopolet.no/medias/sys_master/products/products/hbc/hb0/8834253127710/produkter.csv";
        private HttpClient _httpClient;
        private IVinmonopoletProductRepository _vinmonopoletProductRepository;

        public UpdateVinmonopoletRepositoryCommandHandler(IHttpClientFactory httpClientFactory, IVinmonopoletProductRepository vinmonopoletProductRepository)
        {
            _httpClient = httpClientFactory.CreateClient();
            _vinmonopoletProductRepository = vinmonopoletProductRepository;
        }

        public async Task Handle(UpdateVinmonopoletRepositoryCommand message, IMessageHandlerContext context)
        {
            var vinmonopoletProducts = await FetchNewProductList();
            await _vinmonopoletProductRepository.Store(vinmonopoletProducts);
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
            return new SearchableProduct
            {
                VinmonopoletId = wineProps[1],
                Name = wineProps[2],
                Vintage = wineProps[23],
                Fruit = wineProps[25]
            };
            //Datotid;Varenummer;Varenavn;Volum;Pris;Literpris;Varetype;Produktutvalg;Butikkategori;Fylde;Friskhet;Garvestoffer;Bitterhet;Sodme(14);
            //Farge;Lukt;Smak;Passertil01;Passertil02;Passertil03;Land(21);Distrikt;Underdistrikt;Argang;Rastoff(25);Metode;Alkohol;Sukker;Syre(29);
            //Lagringsgrad;Produsent;Grossist;Distributor;Emballasjetype;Korktype;Vareurl;Okologisk;Biodynamisk;Fairtrade;Miljosmart_emballasje;
            //Gluten_lav_pa;Kosher
        }

    }
}