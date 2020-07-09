using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Models;
using GestionFacturation.Api.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionFacturation.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _manager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(ApplicationDbContext db, UserManager<User> manage,
            SignInManager<User> signInManager)
        {
            _db = db;
            _manager = manage;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model == null)
                return NotFound();
            var user = await _manager.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound();

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok("Login success");
            }
            else if(result.IsLockedOut)
            {
                return Unauthorized("User account is locked");
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}