using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using DomainLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Seed
{
    public class BatchesSeed : ISeed
    {
        Batch[] _batches = new[]
        {
            new Batch()
            {
                CinemaId = 3,
                Cinema = new Cinema()
                {
                    Id = 3, 
                    Capacity=5, 
                },
                MovieId=4,
                Movie = new Movie()
                {
                    Id = 4,
                    Title = "Titanic",
                    RatingId = 4,
                    Rating = new Rating(){Id= 4, Name="D"},
                    DurationTime = new TimeSpan(1, 59, 00),
                    Actors = new[]
                    {
                        new Actor(){Id=5, Name="Leonardo DiCaprio"},
                        new Actor(){Id=6, Name="Kate Winslet"}
                    },
                    Genres = new []
                    {
                        new Genre(){Id=14, Name="Cine catastrófico"}
                    }
                },
                Schedule = new Schedule()
                {
                    StartTime=new DateTime(2021, 08, 10, 10, 20,00),
                    EndTime=new DateTime(2021, 08, 10, 12, 20,00)
                },
                ScheduleStartTime = new DateTime(2021, 08, 10, 10, 20,00),
                ScheduleEndTime = new DateTime(2021, 08, 10, 12, 20,00),
                TicketPoints = 10,
                TicketPrice = 20
            },
            new Batch()
            {
                CinemaId = 1,
                Cinema = new Cinema(){Id=1, Capacity=100 },
                MovieId=5,
                Movie = new Movie()
                {
                    Id = 5,
                    Title = "Bad Boys 2",
                    RatingId = 4,
                    Actors = new[]
                    {
                        new Actor(){Id=9, Name="Will Smith"},
                        new Actor(){Id=10, Name="Martin Lawrence"},
                    },
                    DurationTime = new TimeSpan(1, 20, 00)
                },
                Schedule = new Schedule()
                {
                    StartTime=new DateTime(2021, 06, 10, 10, 20,00),
                    EndTime=new DateTime(2021, 06, 10, 12, 20,00)
                },
                ScheduleStartTime = new DateTime(2021, 06, 10, 10, 20,00),
                ScheduleEndTime = new DateTime(2021, 06, 10, 12, 20,00),
                TicketPoints = 10,
                TicketPrice = 20
            },
            new Batch()
            {
                CinemaId = 1,
                MovieId = 3,
                Movie =  new Movie()
                {
                    Id = 3,
                    Title="Fast & Furious 8",
                    RatingId = 3,
                    Rating = new Rating(){Id=3, Name = "C"},
                    Countries = new [] {new Country(){Id=12, Name="Estados Unidos de América"} },
                    Actors = new []
                    {
                        new Actor() { Id = 7, Name="Dwayne Johnson"},
                        new Actor() { Id = 8, Name = "Vin Diesel"}
                    },
                    Genres = new []{ new Genre() { Id = 16, Name = "Policiaco" } }
                },
               Schedule = new Schedule()
                {
                    StartTime=new DateTime(2021, 07, 10, 10, 20,00),
                    EndTime=new DateTime(2021, 07, 10, 12, 20,00)
                },
                ScheduleStartTime = new DateTime(2021, 07, 10, 10, 20,00),
                ScheduleEndTime = new DateTime(2021, 07, 10, 12, 20,00),
                TicketPoints = 10,
                TicketPrice = 20
            },
            new Batch()
            {
                CinemaId = 1,
                MovieId = 3,
               Schedule = new Schedule()
                {
                    StartTime=new DateTime(2021, 06, 30, 16, 20,00),
                    EndTime=new DateTime(2021, 06, 30, 17, 20,00)
                },
                ScheduleStartTime = new DateTime(2021, 06, 30, 16, 20,00),
                ScheduleEndTime = new DateTime(2021, 06, 30, 17, 20,00),
                TicketPoints = 10,
                TicketPrice = 20
            },
            new Batch()
            {
                CinemaId = 1,
                MovieId = 3,
                Schedule = new Schedule()
                {
                    StartTime=new DateTime(2021, 06, 21, 16, 20,00),
                    EndTime=new DateTime(2021, 06, 21, 17, 20,00)
                },
                ScheduleStartTime = new DateTime(2021, 06, 21, 16, 20,00),
                ScheduleEndTime = new DateTime(2021, 06, 21, 17, 20,00),
                TicketPoints = 10,
                TicketPrice = 20
            }
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var batch in _batches)
            {
                if (batch.Cinema == null)
                    continue;
                var seats = new Seat[batch.Cinema.Capacity];
                for (int i = 1; i <= seats.Length; i++)
                    seats[i - 1] = new Seat() { CinemaId = batch.CinemaId, Id = i };
                batch.Cinema.Seats = seats;
            }

            foreach (var batch in _batches)
                if (!context.Batch.Contains(batch))
                    context.Batch.Add(batch);
            context.SaveChanges();
        }
    }
}
