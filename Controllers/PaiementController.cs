using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    public class PaiementController : BaseController<Paiement>
    {
        public PaiementController(ILogger<BaseController<Paiement>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}