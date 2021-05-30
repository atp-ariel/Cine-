using System.Reflection;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RepositoryLayer.Identity{
    public static class ConfigureIdentity {
        public static void DoConfiguration(IServiceCollection services, IConfiguration configuration){
            foreach(Type type in Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IConfigurationIdentity)))){
                ((IConfigurationIdentity)Activator.CreateInstance(type)).Configure(services, configuration);
            }
        }
    }
}