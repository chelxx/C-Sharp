using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("contact");
        }

        [HttpGet]
        [Route("project")]
        public IActionResult Project()
        {
            return View("project");
        }
    }
}