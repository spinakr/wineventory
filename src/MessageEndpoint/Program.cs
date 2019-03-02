using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using Wineventory.MessageEndpoint.Configuration;
using Wineventory.MessageEndpoint.Vinmonopolet;

namespace Wineventory.MessageEndpoint
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "MessageEndpoint";
            var endpointInstance = await Endpoint.Start(ConfigureEndpoint.Configure()).ConfigureAwait(false);
            await endpointInstance.SendLocal(new UpdateVinmonopoletRepositoryCommand());
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
