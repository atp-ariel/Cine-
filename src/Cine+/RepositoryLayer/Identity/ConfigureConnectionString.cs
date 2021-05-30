using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Identity{
    public class ConfigureConnectionString : IConfigurationIdentity
    {
        void IConfigurationIdentity.Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityContext>(options => options.UseSqlite(configuration.GetConnectionString("CinePlus"),
                                                    optionsBuilder => optionsBuilder.MigrationsAssembly("CineWeb")));
        }
    }
}