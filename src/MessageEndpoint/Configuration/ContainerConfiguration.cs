using System.Net.Http;
using Autofac;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageEndpoint.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure(IConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(HttpClientFactory()).As<IHttpClientFactory>();
            builder.Register<WineContext>(x => DatabaseContext(config)).InstancePerLifetimeScope();

            return builder.Build();
        }

        private static IHttpClientFactory HttpClientFactory()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            return httpClientFactory;
        }

        private static WineContext DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("VinmonopoletProducts");
            var builder = new DbContextOptionsBuilder<WineContext>();
            builder.UseNpgsql(connectionString);
            return new WineContext(builder.Options);
        }
    }
}