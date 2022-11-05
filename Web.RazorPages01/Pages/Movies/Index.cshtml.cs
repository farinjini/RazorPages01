using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.RazorPages01.Data;
using Web.RazorPages01.Models;

namespace Web.RazorPages01.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Web.RazorPages01.Data.AppDataContext _context;
        
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        
        public SelectList ? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        
        public string ? MovieGenre { get; set; }
        

        public IndexModel(Web.RazorPages01.Data.AppDataContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                var movies = _context.Movies.AsQueryable();
                
                if (!string.IsNullOrEmpty(SearchString))
                {
                    movies = movies.Where(s => s.Title.Contains(SearchString.ToLower()));
                }
                
                Movie = await movies.ToListAsync();
            }
            
            
        }
    }
}
