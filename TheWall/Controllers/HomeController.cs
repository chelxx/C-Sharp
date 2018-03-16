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
                    HttpContext.Session.SetString("firstname", user.FirstName);
                    HttpContext.Session.SetString("lastname", user.LastName);
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
            ViewBag.WelcomeName = HttpContext.Session.GetString("firstname");
            ViewBag.WelcomeName2 = HttpContext.Session.GetString("lastname");
            // string readquery = @"SELECT  messages.id, messages.Message, messages.created_at, messages.updated_at, messages.user_id,
            //                     users.FirstName, users.LastName
            //                     FROM TheWall.messages 
            //                     JOIN TheWall.users 
            //                     ON TheWall.messages.user_id 
            //                     WHERE (users.id = messages.user_id)
            //                     ORDER BY messages.created_at DESC";

            string readquery = @"SELECT  messages.id, messages.Message, messages.created_at, messages.updated_at, messages.user_id,
                                users.FirstName, users.LastName, users.id AS the_user_id
                                FROM TheWall.messages 
                                JOIN TheWall.users 
                                ON TheWall.messages.user_id 
                                WHERE (users.id = messages.user_id)
                                ORDER BY messages.created_at DESC";
            var users = DbConnector.Query(readquery);
            ViewBag.thewall = users;
            int? userID = HttpContext.Session.GetInt32("id");
            ViewBag.id = userID;
            foreach(var user in users)
            {
                ViewBag.FirstName = user["FirstName"];
                ViewBag.LastName = user["LastName"];
                ViewBag.created_at = user["created_at"];
                ViewBag.Message = user["Message"];
                ViewBag.MessageID = user["id"];
                ViewBag.user = user["the_user_id"];
            }
            string commentquery = @"SELECT comments.Comment, comments.created_at,  users.FirstName, users.LastName, comments.message_id 
                                    FROM comments 
                                    JOIN users 
                                    ON comments.user_id 
                                    WHERE comments.user_id = users.id";
            var comments = DbConnector.Query(commentquery);
            ViewBag.wallcomment = comments;
            foreach(var comment in comments)
            {
                ViewBag.FirstName = comment["FirstName"];
                ViewBag.LastName = comment["LastName"];
                ViewBag.created_at = comment["created_at"];
                ViewBag.Message = comment["Comment"];
                ViewBag.MessageID = comment["message_id"];
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
                string fname = (string)sessionquery[0]["FirstName"];
                string lname = (string)sessionquery[0]["LastName"];
                HttpContext.Session.SetInt32("id", sessionID);
                var login = DbConnector.Query(loginquery);
                if (login.Count == 1)
                {
                    HttpContext.Session.SetString("firstname", fname);
                    HttpContext.Session.SetString("lastname", lname);
                    ViewBag.WelcomeName = HttpContext.Session.GetString("firstname");
                    ViewBag.WelcomeName2 = HttpContext.Session.GetString("lastname");
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

        // ************** THE MESSAGES ************** //

        [HttpPost]
        [Route("postmessage")]
        public IActionResult PostMessage(string Message)
        {
            // if(Message.Length > 0)
            // {
                System.Console.WriteLine("***** INSERTING MESSAGE QUERY *****");
                int? userID = HttpContext.Session.GetInt32("id");
                string insertmessagequery = $"INSERT INTO TheWall.messages (Message, user_id) VALUES (\"{Message}\", {userID})";
                DbConnector.Execute(insertmessagequery);
                return RedirectToAction("Success");
            // }
            // else
            // {
            //     ViewBag.MessageLength = "Your Message cannot be blank!";
            //     return View("Success");
            // }
        }

        // ************** THE COMMENTS ************** //

        [HttpPost]
        [Route("postcomment/{id}")]
        public IActionResult PostComment(string Comment, int id)
        {
            // if(Comment.Length > 0)
            // {
                System.Console.WriteLine("***** INSERTING COMMENT QUERY *****");
                int? userID = HttpContext.Session.GetInt32("id");
                string insertcommentquery = $"INSERT INTO TheWall.comments (Comment, user_id, message_id, created_at, updated_at) VALUES (\"{Comment}\", {userID}, {id}, NOW(), NOW())";
                DbConnector.Execute(insertcommentquery);
                return RedirectToAction("Success");
            // }
            // else
            // {
            //     ViewBag.CommentLength = "Your Comment cannot be blank!";
            //     return View("Success");
            // }
        }

        // ************** THE COMMENTS ************** //

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult DeleteMine(string Comment, int id)
        {
            // DELETE MESSAGE WORKS BUT THROWS AN ERROR WHEN DELETING A MESSAGE THAT HAS COMMENTS IN IT
            string deletemessagequery = $"DELETE FROM messages WHERE (id = {id})";
            DbConnector.Execute(deletemessagequery);
            return RedirectToAction("Success");
            // WIP
            // string deletecommentquery = $"DELETE FROM comments WHERE (id = {id})";
            // DbConnector.Execute(deletecommentquery);
            // WIP
        }
    }
}
// Notes=[;.'][;]
// #1. How do I append the foreach errors on the same page?
// #2. How do I use session?
// #3. Password Hashing?