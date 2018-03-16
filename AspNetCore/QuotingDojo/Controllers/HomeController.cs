using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("quotes")]
        public IActionResult Quote(string dojoname, string dojoquote)
        {
            // Note: Add validations for the form???
            string name = dojoname;
            string quote = dojoquote;
            string insertquery = $"INSERT INTO QuotingDojo.quotes (name, quote, created_at) VALUES ('{name}', '{quote}', NOW())";
            var users = DbConnector.Query(insertquery);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult CreateQuote(string name, string quote)
        {
            string readquery = "SELECT * FROM QuotingDojo.quotes";
            var users = DbConnector.Query(readquery);
            ViewBag.quotingdojo = users;
            foreach(var user in users)
            {
                ViewBag.name = user["name"];
                ViewBag.quote = user["quote"];
            }
            return View("Quotes");
        }
    }
}