using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using Task_Aplication.Data;
using Task_Aplication.Filters;
using Task_Aplication.Models;
using Task_Aplication.Models.DataBase;
using Web_API;

namespace Task_Aplication.Controllers
{   
    public class LoginController : Controller
    {
        private TasksContext _DbContext;

        public LoginController(TasksContext DbContext) => _DbContext = DbContext;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login user)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData["messageError"] = "Complete los campos";
                return View();
            }

            var findUser = (
                from i in _DbContext.Users
                where i.Email == user.Email && i.Password == Encrypt.GetSHA256(user.Password)
                select i
            ).FirstOrDefault();

            if (findUser == null)
            {
                TempData["MessageError"] = "Correo o contraseña incorrectos";
                return View();
            }

            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            Claim claimRole = new Claim(ClaimTypes.Role, findUser.Rol);
            Claim claimIdUsuario = new Claim("IdUser", findUser.Iduser.ToString());

            identity.AddClaim(claimRole);
            identity.AddClaim(claimIdUsuario);

            ClaimsPrincipal principalUser = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalUser, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddDays(1)
            });

            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(findUser));
            HttpContext.Session.SetString("NameUser", findUser.Names);

            if (findUser.Rol == "USER") { 
                return RedirectToAction("Index", "Home");
            }
            else if (findUser.Rol == "ADMIN")
            {
                return RedirectToAction("Dashboard", "Admin");
            } else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}
