using Database;
using Microsoft.AspNetCore.Mvc;
using Wineventory.Logic.Vinmonopolet;
using Wineventory.Logic.Vinmonopolet.Dtos;
using Wineventory.Web.Utils;

namespace Web.Controllers
{
    [Route("api/vinmonopoletProduct")]
    public class ProductSearchController : Controller
    {
        private WineContext _db;
        private Messaging _messaging;

        public ProductSearchController(WineContext context, Messaging messaging)
        {
            _db = context;
            _messaging = messaging;
        }

        [HttpGet("{vinmonopoletId}")]
        public ProductsSearchResultDto ProductSearch(string vinmonopoletId)
        {
            return _messaging.Dispatch(new ProductSearchQuery(vinmonopoletId));
        }
    }
}
