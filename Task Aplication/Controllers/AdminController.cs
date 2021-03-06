using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task_Aplication.Data;
using Task_Aplication.Filters;

namespace Task_Aplication.Controllers
{
    public class AdminController : Controller
    {
        private TasksContext _DbContext;

        public AdminController(TasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        [AuthorizeUsers(Policy = "Administrators")]
        public ActionResult Dashboard()
        {
            var users = _DbContext.Users.ToList();
            return View(users);
        }
    }
}
