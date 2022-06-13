using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Task_Aplication.Data;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class IndexController : Controller
    {    
        private TasksContext _DbContext;

        public IndexController(TasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            //var findUser = (
            //    from i in _DbContext.Users
            //    where i.Email == user.Email && i.Password == user.Password
            //    select i
            //).FirstOrDefault();

            //var tasks = (from task in _DbContext.Tasks where task.User == user.Iduser select task).ToList();
            
            return View();
        }  

       
    }
}
