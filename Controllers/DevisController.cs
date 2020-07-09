using System;
using System.Collections.Generic;
using System.Linq;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{

    public class DevisController : BaseController<Devis>
    {
        public DevisController(ILogger<BaseController<Devis>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}