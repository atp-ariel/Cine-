using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class AppIdentityContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOption<AppIdentityContext> option) : base(option){ }
    }
}