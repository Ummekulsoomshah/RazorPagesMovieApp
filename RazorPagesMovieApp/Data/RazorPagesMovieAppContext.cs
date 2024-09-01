using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.models;

namespace RazorPagesMovieApp.Data
{
    public class RazorPagesMovieAppContext : DbContext
    {
        public RazorPagesMovieAppContext (DbContextOptions<RazorPagesMovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovieApp.models.Movie> Movie { get; set; } = default!;
    }
}
