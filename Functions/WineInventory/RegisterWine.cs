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

namespace Wineventory.Functions
{
    public static class RegisterWine
    {
        [FunctionName("RegisterWine")]

        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage req,
            [Table(Constants.TableNames.WineInventoryTableName)] out InventoryWine newWine,
            [Table(Constants.TableNames.VinmonopoletWinesTableName)] CloudTable vinmonopoletRepo,
            TraceWriter log)
        {
            dynamic data = req.Content.ReadAsAsync<object>().GetAwaiter().GetResult();

            newWine = new InventoryWine
            {
                PartitionKey = "wine",
                RowKey = Guid.NewGuid().ToString()
            };

            var responseContent = new StringContent(JsonConvert.SerializeObject(newWine));

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = responseContent
            };
        }
    }
}
