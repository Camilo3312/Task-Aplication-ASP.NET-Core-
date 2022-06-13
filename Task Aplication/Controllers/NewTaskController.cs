using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Task_Aplication.Data;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class NewTaskController : Controller
    {
        private TasksContext _DbContext;

        public NewTaskController(TasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            //var findUser = (
            //    from i in _DbContext.Users
            //    where i.Email == user.Email && i.Password == user.Password
            //    select i
            //).FirstOrDefault();
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
