using System;
using System.Collections.Generic;
using System.Linq;
using Marten;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWineQuery : IQuery<InventoryWineDto>
    {
        public string VinmonopoletId { get; set; }
        public GetInventoryWineQuery()
        {

        }
    }

    public class GetInventoryWineQueryHandler : IQueryHandler<GetInventoryWineQuery, InventoryWineDto>
    {
        private readonly IDocumentSession _session;
        public GetInventoryWineQueryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public InventoryWineDto Handle(GetInventoryWineQuery query)
        {
            return _session
                .Query<InventoryWineView>()
                .Select(p => new InventoryWineDto
                {
                    VinmonopoletId = p.Id,
                    Producer = p.Producer,
                    ProductType = p.ProductType,
                    Name = p.Name,
                    Country = p.Country,
                    // public string VinmonopoletId { get; set; }
                    // public string ProductType { get; set; }
                    // public string Producer { get; set; }
                    // public string Name { get; set; }
                    // public string Vintage { get; set; }
                    // public string Fruit { get; set; }
                    // public string Country { get; set; }
                    // public int Price { get; set; }
                })
                .FirstOrDefault(p => p.VinmonopoletId == query.VinmonopoletId);
        }
    }
}