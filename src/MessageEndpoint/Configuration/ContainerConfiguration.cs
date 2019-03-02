using System.Net.Http;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace MessageEndpoint.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(HttpClientFactory()).As<IHttpClientFactory>();

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