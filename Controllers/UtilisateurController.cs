using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    [Authorize(Roles = Roles.Technicien)]
    public class UtilisateurController:BaseController<Utilisateur>
    {
        public UtilisateurController(ILogger<BaseController<Utilisateur>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
