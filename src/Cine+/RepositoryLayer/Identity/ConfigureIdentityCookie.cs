using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RepositoryLayer.Identity
{
    public class ConfigureIdentityCookie : IConfigurationIdentity
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(option => {
                option.LoginPath = "/Identity/SignIn";
                option.AccessDeniedPath = "/Identity/AccessDenied";
                option.ExpireTimeSpan = TimeSpan.FromHours(10);
            });
        }
    }
}