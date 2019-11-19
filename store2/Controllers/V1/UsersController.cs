using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store2.Contracts.V1;
using store2.Contracts.V1.Requests;
using store2.Services;

namespace store2.Controllers.V1
{

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpPost(ApiRoutes.Add.AddUser)]
        public async  Task<IActionResult> Add([FromBody]UserRequest userRequest)
        {
            await usersService.AddAsync(userRequest.Email, userRequest.Password);
            return NoContent();
        }
        [HttpPost(ApiRoutes.Add.Login)]
        public async Task<IActionResult> Login([FromBody]UserRequest userRequest)
        {
            await usersService.LoginAsync(userRequest.Email, userRequest.Password);
            return NoContent();
        }
    }
}