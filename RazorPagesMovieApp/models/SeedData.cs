using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovieApp.Data;
namespace RazorPagesMovieApp.models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider) {

        using ( var context=new RazorPagesMovieAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieAppContext>>()
            )
            )
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange
             (
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating="5"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating="4"
                }
             );
            context.SaveChanges();

        }
    }

}