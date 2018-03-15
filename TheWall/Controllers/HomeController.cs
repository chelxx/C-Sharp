using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
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
                string emailquery = $"SELECT * FROM TheWall.users WHERE(email = '{user.Email}')";
                var email = DbConnector.Query(emailquery);
                if (email.Count == 0)
                {
                    string insertquery = $"INSERT INTO TheWall.users (FirstName, LastName, Email, Password, created_at, updated_at) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}', NOW(), NOW())";
                    DbConnector.Execute(insertquery);
                    HttpContext.Session.SetString("user", user.Email);
                    var sessionquery = DbConnector.Query(emailquery);
                    int sessionID = (int)sessionquery[0]["id"];
                    HttpContext.Session.SetInt32("id", sessionID);
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
                string loginquery = $"SELECT * FROM TheWall.users WHERE(Email = '{user.Email}' AND Password = '{user.Password}')";
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

        // ************** THE WALL ************** //

        [HttpPost]
        [Route("postmessage")]
        public IActionResult PostMessage(string Message, int user_id)
        {
            int? id = HttpContext.Session.GetInt32("id");
            int userID = (int)id;
            string insertmessagequery = $"INSERT INTO TheWall.messages (Message, user_id, created_at, updated_at) VALUES ('{Message}', {userID}, NOW(), NOW())";
            DbConnector.Execute(insertmessagequery);
            return RedirectToAction("Success");
            
        }
    }
}