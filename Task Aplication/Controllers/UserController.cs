using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Task_Aplication.Filters;
using Task_Aplication.Models;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class UserController : Controller
    {
        private tasksContext _DbContext;

        public UserController(tasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        [AuthorizeUsers]
        public IActionResult Index()
        {
            var all_tasks = _DbContext.Tasks.ToList();
            return View(all_tasks);
        }   
    }
}
