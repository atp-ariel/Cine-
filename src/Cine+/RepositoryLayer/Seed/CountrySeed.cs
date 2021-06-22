using Microsoft.AspNetCore.Builder;
using System.Linq;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryLayer.Seed
{
    public class CountrySeedData : ISeed
    {
        #region Data
        private Country[] _countries = new[] 
        { 
            new Country(){Id=1, Name="Japón"},
            new Country(){Id=2, Name="China"},
            new Country(){Id=3, Name="Francia"},
            new Country(){Id=4, Name="Alemania"},
            new Country(){Id=5, Name="España"},
            new Country(){Id=6, Name="Italia"},
            new Country(){Id=8, Name="Reino Unido"},
            new Country(){Id=10, Name="Cuba"},
            new Country(){Id=11, Name="Rusia"},
            new Country(){Id=13, Name="México"},
            new Country(){Id=14, Name="Argentina"},
        };

        #endregion

        #region Method
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var country in _countries)
                if (!context.Country.Contains(country))
                    context.Country.Add(country);
            context.SaveChanges();
        }
        #endregion
    }
}
