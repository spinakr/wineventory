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
        public async Task OnGetAsync(string search = null)
        {
            var result = await _db.FindAsync<SearchableProduct>(search);
            Data = new Model { VinmonopoletId = search };
        }
    }

    public class Model
    {
        public string Name { get; set; }
        public string Vintage { get; set; }
        public string VinmonopoletId { get; set; }
    }
}