using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Services
{
    public interface IUsersService
    {
        Task AddAsync(string email,string password);
        Task LoginAsync(string email,string password);
        //IdentityUser AddUser();
    }
}
