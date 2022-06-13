using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Aplication.Data;
using Task_Aplication.Filters;
using Task_Aplication.Models;
using Task_Aplication.Models.DataBase;

namespace Task_Aplication.Controllers
{
    public class HomeController : Controller
    {
        private TasksContext _DbContext;
        public HomeController(TasksContext DbContext)
        {
            _DbContext = DbContext;
        }

        private List<Task> GetUserTasksListToDo()
        {
            var userSessionInfo = JsonConvert.DeserializeObject<User>(
                HttpContext.Session.GetString("SessionUser")
            );

            var tasks = (
                from task in _DbContext.Tasks
                where task.Iduser == userSessionInfo.Iduser && task.Date > DateTime.Now
                orderby task.Date 
                select task).ToList();
            return tasks;
        }

        private List<Task> GetUserCompletledTasksList()
        {
            var userSessionInfo = JsonConvert.DeserializeObject<User>(
                HttpContext.Session.GetString("SessionUser")
            );

            var tasks = (
                from task in _DbContext.Tasks
                where task.Iduser == userSessionInfo.Iduser && task.Date < DateTime.Now 
                orderby task.Date 
                select task).ToList();
            return tasks;
        }

        [AuthorizeUsers(Policy = "UsersAuthorized")]
        public IActionResult Index()
        {       
            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            return View();
        }

        [AuthorizeUsers(Policy = "UsersAuthorized")]
        public IActionResult AddTask()
        {
            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            return View();       
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            if (!ModelState.IsValid)
            {
                ViewData["MessageError"] = "Complete el formulario";
                return View();
            }

            task.Iduser = JsonConvert.DeserializeObject<User>(
                HttpContext.Session.GetString("SessionUser")
            ).Iduser;
            _DbContext.Tasks.Add(task);
            _DbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        [AuthorizeUsers(Policy = "UsersAuthorized")]
        public IActionResult UpdateTask(int task)
        {
            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            var userSessionInfo = JsonConvert.DeserializeObject<User>(
                HttpContext.Session.GetString("SessionUser")
            );

            var findUser = (
                 from userTask in _DbContext.Tasks
                 where userTask.Iduser == userSessionInfo.Iduser && userTask.Idtask == task
                 select userTask).FirstOrDefault();
            
            if(findUser == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            return View(_DbContext.Tasks.Find(task));
        }


        [HttpPost]
        public IActionResult UpdateTask(Task task)
        {
            ViewBag.TasksListToDo = GetUserTasksListToDo();
            ViewBag.TasksListCompleted = GetUserCompletledTasksList();
            var userSessionInfo = JsonConvert.DeserializeObject<User>(
                HttpContext.Session.GetString("SessionUser")
            );

            if (!ModelState.IsValid)
            {
                ViewData["MessageError"] = "Complete el formulario";
                return View();
            }

            _DbContext.Entry(task).State = EntityState.Modified;     
            _DbContext.SaveChanges();

            var findUser = (
                from userTask in _DbContext.Tasks
                where userTask.Iduser == userSessionInfo.Iduser && userTask.Idtask == task.Idtask
                select userTask).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteTask(int task)
        {
            var deleteTask = _DbContext.Tasks.Find(task);
            _DbContext.Remove(deleteTask);
            _DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
