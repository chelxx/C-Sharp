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

        public DojoController()
        {
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Dojos = dojoFactory.FindDOJOAll();
            return View("Index");
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
        [Route("viewdojo/{dojoID}")]
        public IActionResult CreateDojo(int dojoID)
        {
            ViewBag.Dojos = dojoFactory.FindDOJOByID(dojoID);
            return View("Dojo");
        }

        // [HttpGet]
        // [Route("banish/{id}/{dojo_id}")]
        // public IActionResult Banish(int id, int dojo_id)
        // {
        //     dojoFactory.BanishDOJO(id);
        //     return Redirect($"/dojo/{dojo_id}");
        // }

        // [HttpGet]
        // [Route("recruit/{id}/{dojo_id}")]
        // public IActionResult Recruit(int id, int dojo_id)
        // {
        //     dojoFactory.RecruitDOJO(id, dojo_id);
        //     return Redirect($"/dojo/{dojo_id}");
        // }
    }
}
