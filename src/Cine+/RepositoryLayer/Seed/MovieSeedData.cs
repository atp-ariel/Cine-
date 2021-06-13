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
        private Movie[] _movies = new[]
        {
            new Movie(){
                Id=1, 
                Title="War",
                Countries = new[] {new Country() { Id = 9, Name = "India" } }
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
