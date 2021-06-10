using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Identity;

namespace ServiceLayer.Identity
{
    interface IUserManager
    {
        Task<IEnumerable<AppUser>> GetUsers(string role);
        Task<AppUser> FindByUsername(string username);
    }
}
