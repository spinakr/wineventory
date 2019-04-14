using System;
using System.Threading.Tasks;
using MessageEndpoint.Configuration;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using NServiceBus.Logging;
using Wineventory.MessageEndpoint.Vinmonopolet;

namespace MessageEndpoint
{
    public class Host
    {
        static readonly ILog log = LogManager.GetLogger<Host>();

        IEndpointInstance endpoint;

        public string EndpointName => "MessagingEndpoint";

        public async Task Start()
        {
            try
            {
                var endpointConfiguration = new EndpointConfiguration(EndpointName);
                var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
                transport.ConnectionString("host=rabbitmq");
                transport.UseConventionalRoutingTopology();
                endpointConfiguration.EnableInstallers();
                var container = ContainerConfiguration.Configure(LoadSettings());

                endpointConfiguration.UseContainer<AutofacBuilder>(
                    customizations: customizations =>
                    {
                        customizations.ExistingLifetimeScope(container);
                    });

                endpoint = await Endpoint.Start(endpointConfiguration);
                Console.WriteLine("Endpoint started");

                await endpoint.SendLocal(new UpdateVinmonopoletRepositoryCommand());
                Console.WriteLine("Message sent.");
                Console.WriteLine("Use 'docker-compose down' to stop containers.");
            }
            catch (Exception ex)
            {
                FailFast("Failed to start.", ex);
            }
        }

        public async Task Stop()
        {
            try
            {
                await endpoint?.Stop();
            }
            catch (Exception ex)
            {
                FailFast("Failed to stop correctly.", ex);
            }
        }

        private static IConfiguration LoadSettings()
        {
            var builder = new ConfigurationBuilder();
            return builder.AddJsonFile("appsettings.json", optional: false).Build();
        }

        async Task OnCriticalError(ICriticalErrorContext context)
        {
            try
            {
                await context.Stop();
            }
            finally
            {
                FailFast($"Critical error, shutting down: {context.Error}", context.Exception);
            }
        }

        void FailFast(string message, Exception exception)
        {
            try
            {
                log.Fatal(message, exception);
            }
            finally
            {
                Environment.FailFast(message, exception);
            }
        }
    }
}