using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using Task_Aplication.Filters;
using Task_Aplication.Models;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{   
    public class LoginController : Controller
    {
        private tasksContext _DbContext;

        public LoginController(tasksContext DbContext) => _DbContext = DbContext;

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)         
                return RedirectToAction("Profile", "NewTask");
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login user)
        {
           if (ModelState.IsValid) { 
                var findUser = (from i in _DbContext.Users
                                    where i.Email == user.Email && i.Password == user.Password
                                    select i).FirstOrDefault();

                if (findUser != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    Claim claimRole = new Claim(ClaimTypes.Role, "User");
                    Claim claimIdUsuario = new Claim("IdUser", findUser.Iduser.ToString());

                    identity.AddClaim(claimRole);
                    identity.AddClaim(claimIdUsuario);

                    ClaimsPrincipal principalUser = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalUser, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddDays(1)
                    });

                    //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(findUser));
                    
                    return RedirectToAction("Profile", "NewTask");
                }
           }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
