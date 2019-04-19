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

namespace Web.Controllers
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
        public async Task<ProductSearchResult> ProductSearch(string vinmonopoletId)
        {
            var result = await _db.FindAsync<SearchableProduct>(vinmonopoletId);
            if (result != null)
            {
                return new ProductSearchResult
                {
                    VinmonopoletId = result.Id,
                    Name = result.Name,
                    Vintage = result.Vintage,
                    Producer = result.Producer,
                    Fruit = result.Fruit,
                    Price = result.Price,
                    Country = result.Country,
                    ProductType = result.ProductType
                };
            }
            return null;
        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            var res = _messaging.Dispatch(new AddWineToInventoryCommand());
            return Ok();
        }

        public class ProductSearchResult
        {
            public string VinmonopoletId { get; set; }
            public string Name { get; set; }
            public string Fruit { get; set; }
            public string Vintage { get; set; }
            public double Price { get; set; }
            public string Country { get; set; }
            public string ProductType { get; set; }
            public string Producer { get; set; }
        }
    }
}
