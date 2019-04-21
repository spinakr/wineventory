using System;
using System.Collections.Generic;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWinesQuery : IQuery<List<InventoryWine>>
    {
        public GetInventoryWinesQuery()
        {

        }
    }

    public class GetInventoryWinesQueryHandler : IQueryHandler<GetInventoryWinesQuery, List<InventoryWine>>
    {
        public GetInventoryWinesQueryHandler()
        {

        }

        public List<InventoryWine> Handle(GetInventoryWinesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}