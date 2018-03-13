using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("submit")]
        public IActionResult Submit(User user)
        {
            // IF ELSE statements here for validations
            if (ModelState.IsValid)
            {
                string insertquery = $"INSERT INTO FormSubmission.users (FirstName, LastName, Age, Email, Password) VALUES ('{user.FirstName}','{user.LastName}','{user.Age}','{user.Email}','{user.Password}')";
                DbConnector.Execute(insertquery);
                return View("Success");
            }
            else
            {
                ViewBag.allErrors = ModelState.Values;
                ViewBag.status = "fail";
                return View("Success");
            }
        }
    }
}
