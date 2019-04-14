using System.Net.Http;
using Autofac;
using MessageEndpoint.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace Wineventory.MessageEndpoint.Configuration
{
    public static class ConfigureEndpoint
    {
        public static EndpointConfiguration Configure()
        {
            var endpointConfiguration = new EndpointConfiguration("MessageEndpoint");
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=rabbitmq");
            endpointConfiguration.EnableInstallers();
            var container = ContainerConfiguration.Configure(LoadSettings());

            endpointConfiguration.UseContainer<AutofacBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });

            return endpointConfiguration;
        }

        private static IConfiguration LoadSettings()
        {
            var builder = new ConfigurationBuilder();
            return builder.AddJsonFile("appsettings.json", optional: false).Build();
        }

    }
}