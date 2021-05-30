using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Identity
{
    public class AppIdentityContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> option) : base(option){ }

    }
}