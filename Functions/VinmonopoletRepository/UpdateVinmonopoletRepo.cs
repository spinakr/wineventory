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

namespace Wineventory.Functions
{
    public static class UpdateVinmonopoletRepo
    {
        [FunctionName("UpdateVinmonopoletRepo")]

        public static void Run(
            //{second} {minute} {hour} {day} {month} {day-of-week}
            [TimerTrigger("0 30 9 * * *")]TimerInfo myTimer, //9.30 every day
            [Table(Constants.TableNames.VinmonopoletWinesTableName)] CloudTable vinmonopoletRepo,
            TraceWriter log)
        {
            log.Info("UpateVinmonopoletRepo function trigger on a timed shcdule");


        }
    }
}
