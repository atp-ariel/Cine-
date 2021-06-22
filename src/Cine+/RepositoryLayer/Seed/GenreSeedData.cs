using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RepositoryLayer.Seed
{
    public class GenreSeedData : ISeed
    {
        #region Datas
        private Genre[] _genres = new[]
        {
            new Genre(){Id=2, Name="Ciencia Ficción"},
            new Genre(){Id=4, Name="Drama"},
            new Genre(){Id=5, Name="Fantasía"},
            new Genre(){Id=6, Name="Melodrama"},
            new Genre(){Id=7, Name="Musical"},
            new Genre(){Id=8, Name="Romance"},
            new Genre(){Id=9, Name="Suspenso"},
            new Genre(){Id=11, Name="Documental"},
            new Genre(){Id=12, Name="Cine bélico"},
            new Genre(){Id=13, Name="Cine biográfico"},
            new Genre(){Id=15, Name="Histórico"},
            new Genre(){Id=17, Name="Cine erótico"},
            new Genre(){Id=18, Name="Western"},
            new Genre(){Id=19, Name="Animados"},
            new Genre(){Id=20, Name="3D"}
        };
        #endregion

        #region Methods
        public void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            foreach (var genre in _genres)
                if (!context.Genre.Contains(genre))
                    context.Genre.Add(genre);
            context.SaveChanges();
        }
        #endregion
    }
}
