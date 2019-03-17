using System;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Migration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var connectionString = config.GetConnectionString("AzureSqlConnection");
            var builder = new DbContextOptionsBuilder<WineContext>();
            builder.UseSqlServer(connectionString);
            var dbContext = new WineContext(builder.Options);
            await dbContext.Database.MigrateAsync();
        }
    }
}
