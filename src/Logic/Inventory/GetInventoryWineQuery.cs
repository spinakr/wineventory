using System;
using System.Collections.Generic;
using System.Linq;
using Marten;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWineQuery : IQuery<InventoryWineView>
    {
        public string VinmonopoletId { get; set; }
        public GetInventoryWineQuery(string vinmonopoletId)
        {
            VinmonopoletId = vinmonopoletId;
        }
    }

    public class GetInventoryWineQueryHandler : IQueryHandler<GetInventoryWineQuery, InventoryWineView>
    {
        private readonly IDocumentSession _session;
        public GetInventoryWineQueryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public InventoryWineView Handle(GetInventoryWineQuery query)
        {
            return _session
                .Query<InventoryWineView>()
                .FirstOrDefault(p => p.Id == query.VinmonopoletId);
        }
    }
}