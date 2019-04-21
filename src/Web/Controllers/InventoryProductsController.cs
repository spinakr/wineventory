using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Wineventory.Domain;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;
using Wineventory.Logic.Inventory;
using Wineventory.Web.Utils;

namespace Wineventory.Web.Controllers
{
    [Route("api/inventoryProducts")]
    public class InventoryProductsController : Controller
    {
        private WineContext _db;
        private Messaging _messaging;

        public InventoryProductsController(WineContext context, Messaging messaging)
        {
            _db = context;
            _messaging = messaging;
        }

        [HttpGet("{vinmonopoletId}")]
        public async Task<InventoryWineView> GetInventoryWine(string vinmonopoletId)
        {
            return _messaging.Dispatch(new GetInventoryWineQuery(vinmonopoletId));
        }

        [HttpPost]
        public IActionResult AddToInventory([FromBody]AddBottleOfWineRequest request)
        {
            var res = _messaging.Dispatch(new AddBottleToInventoryCommand(request.VinmonopoletId, request.Producer, request.Name,
                request.Fruit, request.Country, request.Vintage, request.Price, request.ProductType));
            if (res.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(res.ErrorMessage);
        }
    }

    public class AddBottleOfWineRequest
    {
        public string VinmonopoletId { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Country { get; set; }
        public string Vintage { get; set; }
        public int Price { get; set; }
        public string ProductType { get; set; }
    }
}
