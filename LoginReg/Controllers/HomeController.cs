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
                string emailquery = $"SELECT * FROM LoginReg.users WHERE(email = '{user.Email}')";
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
                string loginquery = $"SELECT * FROM LoginReg.users WHERE(Email = '{user.Email}' AND Password = '{user.Password}')";
                var login = DbConnector.Query(loginquery);
                if (login.Count == 1)
                {
                    return View("Success");
                }
                else
                {
                    ViewBag.Email = "Email or Password is incorrect!";
                    return View("Login");
                }
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
// Notes:
// #1. How do I check if session is working?
// #2. I want to display the CURRENT user's name when they register or log in. How do I do that? 
    // I know it has something to do with session... But how? :(