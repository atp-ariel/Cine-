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
        IEnumerable<AppUser> GetUsers();
        Task<AppUser> FindByUsername(string username);
    }
}
