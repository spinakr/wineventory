using System;
using System.Collections.Generic;
using System.Linq;
using Marten;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWineQuery : IQuery<InventoryWineViewProjection.InventoryWineView>
    {
        public string VinmonopoletId { get; set; }
        public GetInventoryWineQuery(string vinmonopoletId)
        {
            VinmonopoletId = vinmonopoletId;
        }
    }

    public class GetInventoryWineQueryHandler : IQueryHandler<GetInventoryWineQuery, InventoryWineViewProjection.InventoryWineView>
    {
        private readonly IDocumentSession _session;
        public GetInventoryWineQueryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public InventoryWineViewProjection.InventoryWineView Handle(GetInventoryWineQuery query)
        {
            return _session
                .Query<InventoryWineViewProjection.InventoryWineView>()
                .FirstOrDefault(p => p.Id == query.VinmonopoletId);
        }
    }
}