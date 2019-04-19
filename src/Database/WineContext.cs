using System;
using Microsoft.EntityFrameworkCore;
using Wineventory.Domain.Vinmonopolet;

namespace Database
{
    public class WineContext : DbContext
    {
        public WineContext(DbContextOptions<WineContext> options)
            : base(options)
        { }

        public DbSet<SearchableProduct> Products { get; set; }
    }
}
