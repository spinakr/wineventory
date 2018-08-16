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

namespace Wineventory.Functions
{
    public static class SearchWine
    {
        [FunctionName("SearchWine")]

        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SearchWine/{vinmonopoletId}")] HttpRequestMessage req,
            [Table(Constants.TableNames.VinmonopoletWinesTableName)] CloudTable vinmonopoletRepo,
            string vinmonopoletId, TraceWriter log)
        {
            var wine = await vinmonopoletRepo.SearchWine(vinmonopoletId);

            if (wine == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"Wine with vinmonompoletId {vinmonopoletId} was not found in vinmonopolet repo")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(wine), Encoding.GetEncoding("ISO-8859-1"))
            };
        }
    }
}
