using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    
    public class ClientController : BaseController<Client>
    {

        public ClientController(ILogger<BaseController<Client>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }



    }
}
