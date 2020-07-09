using System.Collections.Generic;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    public class FactureController : BaseController<Facture>
    {
        public FactureController(ILogger<FactureController> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}