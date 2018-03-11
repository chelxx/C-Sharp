using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        public string name = "Michael Choi";
        public int fullness = 20;
        public int happiness = 20;
        public int meals = 3;
        public int energy = 50;
        public string status;
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.name = name;
            ViewBag.fullness = fullness;
            ViewBag.happiness = happiness;
            ViewBag.meals = meals;
            ViewBag.energy = energy;
            ViewBag.status = status;
            return View("Index");
        }
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            // Feeding costs 1 meal and gains RANDOM fullness (5-10). Can't feed if 0 meals!

            ViewBag.status = "You fed me! That cost 1 meal.";
            // IF fullness or happiness drop to 0, REDIRECT TO LOSE
            // IF fullness and happiness are 100, REDIRECT TO WIN
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            // Playing costs 5 energy and gains RANDOM happiness (5-10).
            ViewBag.status = "I'm playing! ";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            // Working costs 5 energy and earns RANDOM meals (1-3).
            ViewBag.status = "I'm working hard in exchange for {meak count here} meals.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            // Sleeping costs 5 fullness, 5 happiness and earns 15 energy.
            ViewBag.status = "I'm sleeping! Zzzz...";
            return RedirectToAction("Index");
        }
    }
}