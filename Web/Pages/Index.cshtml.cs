using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Backend;
using Web.Backend.Models;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string SearchString { get; set; }    
        public List<Document> DocumentsList { get; set; }

        public void OnGet()
        {
            DocumentsList =  DatabaseAccess.GetDocuments();
        }

        public void OnPost(string searchString)
        {
            SearchString = searchString;
            DocumentsList =  DatabaseAccess.GetDocuments(SearchString);
        }        
    }
}
