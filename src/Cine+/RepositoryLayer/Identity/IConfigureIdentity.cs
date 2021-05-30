using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer.Identity{
    public interface IConfigurationIdentity{
        void Configure(IServiceCollection services, IConfiguration configuration);
    }
}