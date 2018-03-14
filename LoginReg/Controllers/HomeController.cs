using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // GETTING THE LOGIN PAGE. NOTHING MORE, NOTHING LESS
            return View("Index");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegUser user)
        {
            if (ModelState.IsValid) // IF NO VALIDATION ERRORS
            {
                string emailquery = $"SELECT * FROM users WHERE(email = '{user.Email}')";
                var email = DbConnector.Query(emailquery);
                if (email.Count == 0)
                {
                    string insertquery = $"INSERT INTO LoginReg.users (FirstName, LastName, Email, Password) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}')";
                    DbConnector.Execute(insertquery);
                    HttpContext.Session.SetString("user", user.FirstName);
                    var sessionquery = DbConnector.Query(emailquery);
                    int sessionId = (int)sessionquery[0]["id"];
                    return View("Success");
                }
                else
                {
                    ViewBag.allErrors = ModelState.Values;
                    return View("Unsuccess");
                }
            }
            else // IF THERE ARE VALIDATION ERRORS
            {
                ViewBag.allErrors = ModelState.Values;
                return View("Unsuccess");
            }
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            // GETTING THE LOGIN PAGE. NOTHING MORE, NOTHING LESS
            return View("Login");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginUser user)
        {
            if (ModelState.IsValid) // IF NO VALIDATION ERRORS
            {
                string emailquery = $"SELECT * FROM users WHERE(Email = '{user.Email}')";
                var email = DbConnector.Query(emailquery);
                string passwordquery = $"SELECT * FROM users WHERE(Password = '{user.Password}')";
                var password = DbConnector.Query(passwordquery);
                if (email.Count == 1 )
                {
                    return View("Success");
                }
                else
                {
                    ViewBag.Email = "Email does not exist!";
                    ViewBag.Password = "Incorrect Password!";
                    return View("Login");
                }
                // HOW DO I VALIDATE A PASSWORD FROM THE DATABASE AND COMPARE IT TO THE LOGIN INPUT????
            }
            else // IF THERE ARE VALIDATION ERRORS
            {
                ViewBag.allErrors = ModelState.Values;
                return View("Unsuccess");
            }
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
