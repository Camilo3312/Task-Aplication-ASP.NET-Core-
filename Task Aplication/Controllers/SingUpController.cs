using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Aplication.Data;
using Task_Aplication.Models.DataBase;
using Web_API;

namespace Task_Aplication.Controllers
{
    public class SingUpController : Controller
    {
        private dbtasksContext _DbContext;

        public SingUpController(dbtasksContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IActionResult Index() 
        {
            //if (HttpContext.Session.GetString("SessionUser") != null)
            //{
            //    return RedirectToAction("Profile", "NewTask");
            //};
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Encrypt.GetSHA256(user.Password);
                _DbContext.Users.Add(user);
                _DbContext.SaveChanges();
                return RedirectToAction("Index", "Login");
            }

            TempData["messageError"] = "Complete el formulario";
            return View();
        }
    }
}
