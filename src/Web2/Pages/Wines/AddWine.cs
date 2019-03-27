using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wineventory.Domain;

namespace Web.Pages.Wines
{
    public class AddWine : PageModel
    {
        private WineContext _db;

        public AddWine(WineContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Model Data { get; set; }
        public async Task OnGetAsync(string vinmonopoletId = null)
        {
            if (vinmonopoletId == null)
            {
                return;
            }
            var result = await _db.FindAsync<SearchableProduct>(vinmonopoletId);
            if (result != null)
            {
                Data = new Model
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
        }
    }

    public class Model
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