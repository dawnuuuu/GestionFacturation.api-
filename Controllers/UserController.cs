using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    
    public class UserController : BaseController<User>
    {
        public UserController(ILogger<BaseController<User>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
