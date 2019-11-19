using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Contracts.V1.Requests
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
