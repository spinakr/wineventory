using System;
using System.Collections.Generic;
using System.Linq;
using Marten;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWinesQuery : IQuery<InventoryWinesViewProjection.InventoryWinesView>
    {
        public GetInventoryWinesQuery() { }
    }

    public class GetInventoryWinesQueryHandler : IQueryHandler<GetInventoryWinesQuery, InventoryWinesViewProjection.InventoryWinesView>
    {
        private readonly IDocumentSession _session;
        public GetInventoryWinesQueryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public InventoryWinesViewProjection.InventoryWinesView Handle(GetInventoryWinesQuery query)
        {
            return _session
                .Query<InventoryWinesViewProjection.InventoryWinesView>()
                .FirstOrDefault();
        }
    }
}