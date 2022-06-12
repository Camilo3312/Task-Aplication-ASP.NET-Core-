using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class SingUpController : Controller
    {
        private tasksContext _DbContext;

        public SingUpController(tasksContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IActionResult Index() 
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                return RedirectToAction("Profile", "NewTask");
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            //TempData["message_alert"] = "Clickeado";
            if (ModelState.IsValid)
            {
                _DbContext.Users.Add(user);
                _DbContext.SaveChanges();
               
            }
            return View();
        }

    }
}
