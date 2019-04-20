using System;
using System.Collections.Generic;
using Wineventory.Domain.Decorators;
using Wineventory.Domain.Utils;

namespace Wineventory.Logic.Inventory
{
    public class GetInventoryWinesQuery : IQuery<List<InventoryWineDto>>
    {
        public GetInventoryWinesQuery()
        {

        }
    }

    public class GetInventoryWinesQueryHandler : IQueryHandler<GetInventoryWinesQuery, List<InventoryWineDto>>
    {
        public GetInventoryWinesQueryHandler()
        {

        }

        public List<InventoryWineDto> Handle(GetInventoryWinesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}