using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Wineventory.Domain;
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

        [HttpGet]
        public async Task<IEnumerable<InventoryWineDto>> ProductSearch(string vinmonopoletId)
        {
            return new List<InventoryWineDto>();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]InventoryWineDto wine)
        {
            var req = Request.Body;
            var res = _messaging.Dispatch(new AddWineToInventoryCommand(wine));
            if (res.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(res.ErrorMessage);
        }
    }
}
