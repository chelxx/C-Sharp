using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{

    public class HomeController : Controller
    {
        private RestaurantContext _context;
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("createReview")]
        public IActionResult createReview(Restaurant newRestaurant)
        {   
            if(ModelState.IsValid)
            {
                _context.Add(newRestaurant);
                _context.SaveChanges();
                return RedirectToAction("Review");
            }
            else
            {
                return View("Index");
            }
        }   

        [HttpGet]
        [Route("reviews")]
        public IActionResult Review()
        {
            List<Restaurant> rName = _context.restauranter.ToList();
            ViewBag.Reviews = rName.OrderBy(r => r.DateVisit);
            return View("Reviews");
        }
    }
}