using System.Net.Http;
using Autofac;
using MessageEndpoint.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace Wineventory.MessageEndpoint.Configuration
{
    public static class ConfigureEndpoint
    {
        public static EndpointConfiguration Configure()
        {
            var endpointConfiguration = new EndpointConfiguration("MessageEndpoint");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var container = ContainerConfiguration.Configure();

            endpointConfiguration.UseContainer<AutofacBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });

            return endpointConfiguration;
        }

    }
}