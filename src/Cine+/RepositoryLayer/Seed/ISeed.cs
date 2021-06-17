using Microsoft.AspNetCore.Builder;

namespace RepositoryLayer.Seed
{
    public interface ISeed
    {
        void EnsurePopulated(IApplicationBuilder app);
    }
}
