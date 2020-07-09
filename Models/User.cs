using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Auth;
using Microsoft.AspNetCore.Identity;

namespace GestionFacturation.Api.Models
{
    public class User: IdentityUser
    {

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ApiAccessLevels ApiAccessLevels { get; set; }

    }
}
