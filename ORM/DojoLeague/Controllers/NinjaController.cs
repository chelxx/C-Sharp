using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Factory;
using DojoLeague.Models;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {

        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Ninjas()
        {
            ViewBag.Dojos = dojoFactory.FindDOJOAll();
            ViewBag.Ninjas = ninjaFactory.FindNINJAAll();
            return View("Index");
        }
        [HttpPost]
        [Route("createninja")]
        public IActionResult CreateNinjaProcess(Ninja ninja)
        {
            ninjaFactory.AddNINJA(ninja);
            return RedirectToAction("Ninjas");
        }
        [HttpGet]
        [Route("viewninja/{ninjaID}")]
        public IActionResult CreateDojo(int ninjaID)
        {
            var find = ninjaFactory.FindNINJAByID(ninjaID);
            if (find != null)
            {
                ViewBag.Ninjas = ninjaFactory.FindNINJAByID(ninjaID);
                return View("Ninja");
            }
            else{
                ViewBag.Ninjas = ninjaFactory.FindRogueNINJAByID(ninjaID);
                return View("Ninja"); 
            }
        }
    }
}