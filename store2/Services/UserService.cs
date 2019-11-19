using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static store2.Contracts.V1.ApiRoutes;

namespace store2.Services
{
    public class UserService : IUsersService
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager,SignInManager<IdentityUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task AddAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email };
            var result = await _userManager.CreateAsync(user, password);
        }

        public async Task LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password,false,false);
        }
    }
}
