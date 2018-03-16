using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Models;
using LostInTheWoods.Factory;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;

        public HomeController()
        {
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View("Index");
        }

        [HttpGet]
        [Route("createtrail")]
        public IActionResult CreateTrail()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("createtrail")]
        public IActionResult CreateTrailProcess(Trail newTrail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(newTrail);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Errors = "Please fill out the fields completely!";
                return View("Add");
            }
        }

        [HttpGet]
        [Route("viewtrail/{trailID}")]
        public IActionResult CreateTrail(int trailID)
        {
            ViewBag.Trails = trailFactory.FindByID(trailID);
            return View("Trail");
        }
    }
}
