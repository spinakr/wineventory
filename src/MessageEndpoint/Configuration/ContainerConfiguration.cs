using System.Net.Http;
using Autofac;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Storage;

namespace MessageEndpoint.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(HttpClientFactory()).As<IHttpClientFactory>();
            builder.RegisterInstance(new InMemoryVinmonopoletProductRepository()).As<IVinmonopoletProductRepository>();

            return builder.Build();
        }

        private static IHttpClientFactory HttpClientFactory()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            return httpClientFactory;
        }
    }
}