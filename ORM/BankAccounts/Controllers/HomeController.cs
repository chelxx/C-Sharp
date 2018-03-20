using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
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

        [HttpGet]
        [Route("login")]
        public IActionResult LoginView()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser()
        {
            return View("Login");
        }
    }
}
