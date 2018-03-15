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
                    HttpContext.Session.SetString("username", user.FirstName);
                    var sessionquery = DbConnector.Query(emailquery);
                    int sessionID = (int)sessionquery[0]["id"];
                    HttpContext.Session.SetInt32("id", sessionID);
                    return RedirectToAction("Success");
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
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            ViewBag.WelcomeName = HttpContext.Session.GetString("username");
            string readquery = @"SELECT  messages.id, messages.Message, messages.created_at, messages.updated_at, messages.user_id,
                                users.FirstName, users.LastName
                                FROM TheWall.messages 
                                JOIN TheWall.users 
                                ON TheWall.messages.user_id 
                                WHERE (users.id = messages.user_id)
                                ORDER BY messages.created_at DESC";
            var users = DbConnector.Query(readquery);
            ViewBag.thewall = users;
            int? userID = HttpContext.Session.GetInt32("id");
            foreach(var user in users)
            {
                ViewBag.FirstName = user["FirstName"];
                ViewBag.LastName = user["LastName"];
                ViewBag.created_at = user["created_at"];
                ViewBag.Message = user["Message"];
            }
            return View("Success");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginUser user)
        {
            if (ModelState.IsValid) // IF NO VALIDATION ERRORS
            {
                // IF PASSWORD IS HASHED, ADD THAT BUSINESS HERE AND MODIFY LOGINQUERY
                string loginquery = $"SELECT * FROM TheWall.users WHERE(Email = '{user.Email}' AND Password = '{user.Password}')";
                string emailquery = $"SELECT * FROM TheWall.users WHERE(email = '{user.Email}')";                
                var sessionquery = DbConnector.Query(emailquery);
                int sessionID = (int)sessionquery[0]["id"];
                HttpContext.Session.SetInt32("id", sessionID);
                // HttpContext.Session.SetString("username", user.FirstName);
                var login = DbConnector.Query(loginquery);
                if (login.Count == 1)
                {
                    return RedirectToAction("Success");
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
        public IActionResult PostMessage(string Message)
        {
            // I STILL NEED TO DO IF-ELSE STATEMENTS TO INCLUDE VALIDATIONS
            System.Console.WriteLine("***** INSERTING MESSAGE QUERY *****");
            int? userID = HttpContext.Session.GetInt32("id");
            string insertmessagequery = $"INSERT INTO TheWall.messages (Message, user_id) VALUES (\"{Message}\", {userID})";
            DbConnector.Execute(insertmessagequery);
            return RedirectToAction("Success");
        }
    }
}
// Notes:
// #1. How do I append the foreach errors on the same page?
// #2. How do I use session?
// #3. Password Hashing?