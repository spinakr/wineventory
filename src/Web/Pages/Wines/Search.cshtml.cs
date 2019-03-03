using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Wines
{
    public class Search : PageModel
    {
        public SearchResult Result;
        public void OnGet(string vinmonopoletId)
        {
            Result = new SearchResult { Name = "Test Wine", Vintage = "2001", VinmonopoletId = vinmonopoletId };
        }
    }

    public class SearchResult
    {
        public string Name { get; set; }
        public string Vintage { get; set; }
        public string VinmonopoletId { get; set; }
    }
}