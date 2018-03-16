using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
 
namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi") == null) // If a Dojodachi does not exist, create one.
            {
                Dojodachi michaelchoi = new Dojodachi(); // New Dojodachi
                HttpContext.Session.SetObjectAsJson("dachi", michaelchoi); // 
            }
            ViewBag.michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            if(ViewBag.michaelchoi.fullness < 1 || ViewBag.michaelchoi.happiness < 1)
            {
                ViewBag.michaelchoi.status = "Wow, good job in keeping me alive. *sarcasm*";
                return View(viewName: "lose");
            }
            if(ViewBag.michaelchoi.fullness >= 100 && ViewBag.michaelchoi.happiness >= 100)
            {
                ViewBag.michaelchoi.status = "I didn't think you could actually keep me alive but look at us now. Congrats!";
                return View(viewName: "win");
            }
            return View(viewName: "index");
        }
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            Dojodachi michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            michaelchoi.feed();
            HttpContext.Session.SetObjectAsJson("dachi", michaelchoi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            Dojodachi michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            michaelchoi.play();
            HttpContext.Session.SetObjectAsJson("dachi", michaelchoi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            Dojodachi michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            michaelchoi.work();
            HttpContext.Session.SetObjectAsJson("dachi", michaelchoi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            Dojodachi michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            michaelchoi.sleep();
            HttpContext.Session.SetObjectAsJson("dachi", michaelchoi);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("reset")]
        public IActionResult Reset()
        {
            Dojodachi michaelchoi = HttpContext.Session.GetObjectFromJson<Dojodachi>("dachi");
            michaelchoi.reset();
            HttpContext.Session.SetObjectAsJson("dachi", michaelchoi);
            return RedirectToAction("Index");
        }
    }
}