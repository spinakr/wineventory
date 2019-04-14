using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Migration
{

    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<WineContext>
    {
        public WineContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var connectionString = config.GetConnectionString("VinmonopoletProducts");
            var builder = new DbContextOptionsBuilder<WineContext>();
            builder.UseNpgsql(connectionString);
            var dbContext = new WineContext(builder.Options);
            return dbContext;
        }
    }
}