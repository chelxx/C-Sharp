using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace views_prac.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}