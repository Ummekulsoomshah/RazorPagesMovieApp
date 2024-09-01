using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.models;

namespace RazorPagesMovieApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieApp.Data.RazorPagesMovieAppContext _context;

        public IndexModel(RazorPagesMovieApp.Data.RazorPagesMovieAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet=true)]
        public string? MovieGenre { get; set; }
        public DateTime? SearchMovieDate { get; set; }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString) || s.Genre.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            if (StartDate.HasValue)
            {

                movies = movies.Where(s => s.ReleaseDate >= StartDate.Value);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }    
}
