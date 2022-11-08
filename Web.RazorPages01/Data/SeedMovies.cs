using Microsoft.EntityFrameworkCore;
using Web.RazorPages01.Models;

namespace Web.RazorPages01.Data;

public static class SeedMovies
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDataContext(serviceProvider.GetRequiredService<DbContextOptions<AppDataContext>>()))
        {
            if (context?.Movies == null)
                throw new ArgumentNullException("No context provided");

            //Check if there are any movies in the database and exit the seed if there are
            if (context.Movies.Any())
                return;
            
            context.Movies.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    Synopsis = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    Synopsis = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    Synopsis = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    Synopsis = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "R"
                }
                );

            context.SaveChanges();
        }
    }
}