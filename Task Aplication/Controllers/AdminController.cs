using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Aplication.Filters;

namespace Task_Aplication.Controllers
{
    public class AdminController : Controller
    {
       
        [AuthorizeUsers(Policy = "Administrators")]
        public ActionResult Dashboard()
        {

            return View();
        }


    }
}
