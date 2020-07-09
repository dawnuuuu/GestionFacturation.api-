using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Auth;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{
    public class StockController : BaseController<Stock>
    {
        public StockController(ILogger<BaseController<Stock>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
