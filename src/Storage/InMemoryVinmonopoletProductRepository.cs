using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Wineventory.Domain;

namespace Storage
{
    public class InMemoryVinmonopoletProductRepository : IVinmonopoletProductRepository
    {
        private static List<SearchableProduct> _db = new List<SearchableProduct>();
        public Task<SearchableProduct> Find(string vinmonopoletId)
        {
            return Task.FromResult(_db.SingleOrDefault(x => x.VinmonopoletId == vinmonopoletId));
        }

        public Task Store(SearchableProduct product)
        {
            if (product != null)
            {
                _db.Add(product);
            }
            return Task.CompletedTask;
        }

        public Task Store(IEnumerable<SearchableProduct> products)
        {
            if (products != null && products.Any())
            {
                _db.AddRange(products);
            }
            return Task.CompletedTask;
        }
    }
}
