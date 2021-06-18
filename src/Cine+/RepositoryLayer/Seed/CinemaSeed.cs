using Microsoft.AspNetCore.Builder;
using System;
using DomainLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace RepositoryLayer.Seed
{
    public class CinemaSeed : ISeed
    {
        private Cinema[] cinemas = new[] { 
            new Cinema(){Id=1, Capacity=100 },
            new Cinema(){Id=2, Capacity=200},
            new Cinema(){Id=3, Capacity=50}
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach(var cinema in cinemas)
            {
                cinema.Seats = new List<Seat>();
                for (int i = 1; i <= cinema.Capacity; i++)
                    cinema.Seats.Add(new Seat() { Id = i, Cinema = cinema, CinemaId = cinema.Id });
            }
            foreach (var cinema in cinemas)
                if (!context.Cinema.Contains(cinema))
                    context.Add(cinema);
            context.SaveChanges();
        }
    }
}
