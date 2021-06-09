using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;

namespace ServiceLayer.Identity
{
    interface IAuthorizeUserManager
    {
        Task<IdentityResult> SignUp(SignUpModel model);
        Task<SignInResult> Login(SignInModel model);
        void Logout();
    }
}
