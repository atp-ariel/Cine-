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
    public class TicketPurshaceSeed : ISeed
    {
        public PhysicalTicketPurchase[] tickets = new[]
        {
            new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime = new DateTime(2021, 08, 10, 10, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 08, 10, 12, 20,00),
                DiscountListId =1,
                CinemaId = 3,
                SeatId=1,
                DiscountList = new DiscountList()
                {
                    Id= 1,
                    Discounts = new []
                    {
                        new Discount(){Id=4, Name="Niños", DiscountedMoney=3f}
                    },
                },
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 06, 27, 8, 30, 59),
            },
            new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime =  new DateTime(2021, 06, 21, 16, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 06, 21, 17, 20,00),
                DiscountListId =1,
                CinemaId = 1,
                SeatId=1,
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 06, 21, 14, 30, 59),
            },
            new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime =  new DateTime(2021, 06, 21, 16, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 06, 21, 17, 20,00),
                DiscountListId =1,
                CinemaId = 1,
                SeatId=2,
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 06, 21, 14, 31, 59),
            },
             new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime =  new DateTime(2021, 06, 21, 16, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 06, 21, 17, 20,00),
                DiscountListId =1,
                CinemaId = 1,
                SeatId=3,
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 06, 21, 14, 31, 20),
            },
             new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime =  new DateTime(2021, 06, 30, 16, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 06, 30, 17, 20,00),
                DiscountListId =1,
                CinemaId = 1,
                SeatId=1,
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 05, 30, 14, 31, 20),
            },
             new PhysicalTicketPurchase()
            {
                BatchScheduleStartTime =  new DateTime(2021, 06, 21, 16, 20,00),
                BatchScheduleEndTime = new DateTime(2021, 06, 21, 17, 20,00),
                DiscountListId =1,
                CinemaId = 1,
                SeatId=3,
                Paid = true,
                Price = 17f,
                TimeReserve = new DateTime(2021, 06, 21, 14, 31, 20),
            },
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var ticket in tickets)
                if (!context.TicketPurchase.Contains(ticket))
                    context.TicketPurchase.Add(ticket);
            
            context.SaveChanges();
        }
    }
}
