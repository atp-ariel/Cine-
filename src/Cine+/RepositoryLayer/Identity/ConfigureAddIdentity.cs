using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace RepositoryLayer.Identity{
    public class ConfigureAddIdentity : IConfigurationIdentity
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();
        }
    }
}