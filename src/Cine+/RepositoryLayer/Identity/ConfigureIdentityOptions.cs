using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;

namespace RepositoryLayer.Identity{
    public class ConfigureIdentityOptions : IConfigurationIdentity
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });
        }
    }
}