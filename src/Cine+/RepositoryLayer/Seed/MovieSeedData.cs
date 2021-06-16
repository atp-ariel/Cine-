using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Seed
{
    public class MovieSeedData : ISeed
    {
        private Movie[] _movies = new Movie[] { 
            new Movie(){
                Id=1, 
                Title="War",
                RatingId = 2,
                Rating =  new Rating(){Id=2, Name="B"},
                Countries = new[] {new Country() { Id = 9, Name = "India" } },
                Actors = new []{ new Actor() { Id = 1, Name = "Hrithik Roshan" } },
                Genres = new [] { new Genre() { Id = 1, Name = "Acción" } }
            },
            new Movie()
            {
                Id=2,
                Title="Parasite",
                RatingId = 1,
                Rating =  new Rating(){Id=1, Name="A"},
                Countries = new[] { new Country() { Id = 7, Name = "Corea del Sur" } },
                Actors = new[] { new Actor() { Id = 4, Name = "Cho Yeo-jeong" } },
                Genres = new [] { new Genre() { Id = 3, Name = "Comedia" } , new Genre() { Id = 10, Name = "Terror" } }
            }
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var movie in _movies)
                if (!context.Movie.Contains(movie))
                    context.Add(movie);
            context.SaveChanges();
        }
    }
}
