using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFacturation.Api.Controllers
{

    public class CategorieController : BaseController<Categorie>
    {
        public CategorieController(ILogger<BaseController<Categorie>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }
    }
}
