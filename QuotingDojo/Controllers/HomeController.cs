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
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            return View("Quotes");
        }
        [HttpPost]
        [Route("quotes")]
        public IActionResult CreateQuote()
        {
            return RedirectToAction("Index");
        }
    }
}
