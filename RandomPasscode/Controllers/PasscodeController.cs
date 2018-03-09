
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace RandomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}