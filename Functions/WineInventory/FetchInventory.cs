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
using System.Collections.Generic;

namespace Wineventory.Functions
{
    public static class FetchInventory
    {
        [FunctionName("FetchInventory")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req,
            [Table(Constants.TableNames.WineInventoryTableName)] CloudTable wineInventory,
            TraceWriter log)
        {
            var querySegment = wineInventory.ExecuteQuerySegmentedAsync(new TableQuery<InventoryWine>(), null);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(querySegment.Result), Encoding.UTF8, "application/json")
            };
        }
    }
}
