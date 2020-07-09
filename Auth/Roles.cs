using Microsoft.AspNetCore.Identity;

namespace GestionFacturation.Api.Auth
{
    public class Roles : IdentityRole
    {
        public const string Admin = "Admin";
        public const string Technicien = "Technicien";
    }
}