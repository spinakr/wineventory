using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Functions.VinmonopoletRepository;
using System.Collections.Generic;
using System.Linq;

namespace Wineventory.Functions
{
    public static class UpdateVinmonopoletRepo
    {
        private const string ProductFilePath = "https://www.vinmonopolet.no/medias/sys_master/products/products/hbc/hb0/8834253127710/produkter.csv";

        [FunctionName("UpdateVinmonopoletRepo")]
        public static async Task Run(
            [TimerTrigger("0 30 9 * * 1", RunOnStartup = false)]TimerInfo myTimer, //9.30 every monday
            [Table(Constants.TableNames.VinmonopoletWinesTableName)] CloudTable vinmonopoletRepo,
            TraceWriter log)
        {
            var newProductList = (await FetchNewProductList()).ToList();
            var newProductCount = newProductList.Count();

            await InsertEntitieBatched(vinmonopoletRepo, newProductList, newProductCount);

            log.Info($"Imported {newProductCount} products into vinmonopolet repository");
        }

        private static async Task InsertEntitieBatched(CloudTable vinmonopoletRepo, IEnumerable<VinmonopoletWine> newProductList, int productCount)
        {
            var taskCount = 0;
            var taskThreshold = 200; // Seems to be a good value to start with
            var batchTasks = new List<Task<IList<TableResult>>>();

            for (var i = 0; i < productCount; i += 100)
            {
                taskCount++;
                var batchItems = newProductList.Skip(i).Take(100).ToList();
                var batch = new TableBatchOperation();
                foreach (var item in batchItems)
                {
                    batch.InsertOrReplace(item);
                }

                var task = vinmonopoletRepo.ExecuteBatchAsync(batch);
                batchTasks.Add(task);

                if (taskCount >= taskThreshold)
                {
                    await Task.WhenAll(batchTasks);
                    taskCount = 0;
                }
            }

            await Task.WhenAll(batchTasks);
        }

        private static async Task<IEnumerable<VinmonopoletWine>> FetchNewProductList()
        {
            var client = HttpClientFactory.Create();
            var stream = await client.GetStreamAsync(ProductFilePath);
            var streamReader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1"));
            await streamReader.ReadLineAsync(); //skip header

            var wineInfoEntities = new List<VinmonopoletWine>();
            while (true)
            {
                var line = await streamReader.ReadLineAsync();
                if (line == null) break;
                wineInfoEntities.Add(MapToWineInfo(line.Split(';')));
            }
            return wineInfoEntities;
        }

        private static VinmonopoletWine MapToWineInfo(string[] wineProps)
        {
            return new VinmonopoletWine(wineProps[1])
            {
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
