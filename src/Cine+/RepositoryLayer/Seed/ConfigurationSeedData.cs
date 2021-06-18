using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using DomainLayer;

namespace RepositoryLayer.Seed
{
    public class ConfigurationSeedData : ISeed
    {
        private Configurations[] _configurations = new[]
        {
            new Configurations(){KeyConfig = "SelectedCriteria", Value="Películas en orden aleatorio" }
        };
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var config in _configurations)
                if (!context.Configurations.Contains(config))
                    context.Add(config);
            context.SaveChanges();
        }
    }
}
