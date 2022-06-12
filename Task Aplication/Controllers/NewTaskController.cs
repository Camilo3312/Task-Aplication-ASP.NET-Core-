using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class NewTaskController : Controller
    {
        private tasksContext _DbContext;

        public NewTaskController(tasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
