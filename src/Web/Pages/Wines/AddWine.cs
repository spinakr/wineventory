using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Wines
{
    public class AddWine : PageModel
    {

        [BindProperty]
        public Model Data { get; set; }
        public void OnGet(string search = null)
        {
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