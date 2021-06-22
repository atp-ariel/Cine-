using Microsoft.AspNetCore.Builder;
using System;
using DomainLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RepositoryLayer.Seed
{
    public class DiscountSeed : ISeed
    {
        private Discount[] discounts = new[]
        {
            new Discount(){Id = 1, DiscountedMoney=0.20f, Name="FEU" },
            new Discount(){Id = 2, DiscountedMoney=1f, Name="Tercera Edad"},
            new Discount(){Id = 3, DiscountedMoney=1.2f, Name="Trabajadores del ICRT"}
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var discount in discounts)
                if (!context.Discount.Contains(discount))
                    context.Discount.Add(discount);
            context.SaveChanges();
        }
    }
}
