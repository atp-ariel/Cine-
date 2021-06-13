using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryLayer.Seed
{
    public class ActorSeedData : ISeed
    {
        #region Datas
        private Actor[] _actors = new[]
        {
            new Actor(){Id=1, Name="Hrithik Roshan"},
            new Actor(){Id=2, Name="Adam Sandler"},
            new Actor(){Id=3, Name="Julia Fox"},
            new Actor(){Id=4, Name="Cho Yeo-jeong"},
            new Actor(){Id=5, Name="Leonardo DiCaprio"},
            new Actor(){Id=6, Name="Kate Winslet"}
        };
        #endregion

        #region Methods
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var actor in _actors)
                if (!context.Actor.Contains(actor))
                    context.Add(actor);
            context.SaveChanges();
        }
        #endregion
    }
}
