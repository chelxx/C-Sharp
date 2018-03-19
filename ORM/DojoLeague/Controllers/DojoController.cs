using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;

        public DojoController()
        {
            dojoFactory = new DojoFactory();
            ninjaFactory = new NinjaFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Dojos = dojoFactory.FindDOJOAll();
            return View("Index");
        }

        [HttpGet]
        [Route("banish/{ninjaID}/{dojoID}")]
        public IActionResult BanishNinjaProcess(int ninjaID, int dojoID)
        {
            ninjaFactory.BanishNINJA(ninjaID);
            return Redirect($"/viewdojo/{dojoID}");
        }

        [HttpGet]
        [Route("recruit/{ninjaID}/{dojoID}")]
        public IActionResult Recruit(int ninjaID, int dojoID)
        {
            ninjaFactory.RecruitNINJA(ninjaID, dojoID);
            return Redirect($"/viewdojo/{dojoID}");
        }

        [HttpPost]
        [Route("createdojo")]
        public IActionResult CreateDojoProcess(Dojo newDojo)
        {
            if(ModelState.IsValid)
            {
                dojoFactory.AddDOJO(newDojo);
                return RedirectToAction("Index");
            }
            else
            {
                // TEMPDATA NOT SHOWING ON REDIRECT?
                TempData["Errrors"] = "Please fill out the form completely!";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("viewdojo/{id}")]
        public IActionResult CreateDojo(int id)
        {
            ViewBag.Dojos = dojoFactory.FindDOJOByID(id);
            ViewBag.ResidentNinjas = ninjaFactory.FindNINJAByDOJO(id);
            ViewBag.RogueNinjas = ninjaFactory.FindRogueNINJAS();
            return View("Dojo");
        }
    }
}
