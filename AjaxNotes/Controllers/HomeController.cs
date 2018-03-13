using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(string notetitle, string notedescription)
        {
            System.Console.WriteLine("At the INDEX page!");
            string readquery = "SELECT * FROM AjaxNotes.notes";
            var users = DbConnector.Query(readquery);
            ViewBag.ajaxnotes = users;
            foreach(var user in users)
            {
                ViewBag.title = user["title"];
                ViewBag.description = user["description"];
            }
            return View();
        }
        [HttpPost]
        [Route("addnote")]
        public IActionResult CreateNote(string notetitle, string notedescription)
        {
            // Note: Add validations for the form???
            string title = notetitle;
            string description = notedescription;
            // A SQL query syntax error pops up in the browser when I use apostrophes in my sentences??? 
            string insertquery = $"INSERT INTO AjaxNotes.notes (title, description, created_at) VALUES ('{title}', '{description}', NOW())";
            var users = DbConnector.Query(insertquery);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult DeleteNote(int id)
        {
            string deletequery = $"DELETE FROM AjaxNotes.notes WHERE id='{id}'";
            DbConnector.Execute(deletequery);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowNote(int id, string notetitle, string notedescription)
        {
            string readquery = $"SELECT * FROM AjaxNotes.notes WHERE id='{id}'";
            var users = DbConnector.Query(readquery);
            ViewBag.ajaxnotes = users;
            foreach(var user in users)
            {
                ViewBag.title = user["title"];
                ViewBag.description = user["description"];
            }
            return View("Show");
        }
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateNote(int id, string notetitle, string notedescription)
        {
            string title = notetitle;
            string description = notedescription;
            string updatequery = $"UPDATE AjaxNotes.notes SET title='{title}', description='{description}' WHERE id='{id}'";
            DbConnector.Execute(updatequery);
            return RedirectToAction("Index");
        } 
    }
}