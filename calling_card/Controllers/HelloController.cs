using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace calling_card.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Home()
        {
            return "Hello! This is my Calling Card assignment.";
        }

        [HttpGet]
        [Route("{firstname}")]
        public JsonResult FirstName(string firstname)
        {
            var AnonObject = new
            {
                FirstName = firstname
            };
            return Json (AnonObject);
        }

        [HttpGet]
        [Route("{lastname}")]
        public JsonResult LastName(string lastname)
        {
            var AnonObject = new
            {
                LastName = lastname
            };
            return Json (AnonObject);
        }

        [HttpGet]
        [Route("{age}")]
        public JsonResult Age(int age)
        {
            var AnonObject = new
            {
                Age = age
            };
            return Json (AnonObject);
        }

        [HttpGet]
        [Route("{favecolor}")]
        public JsonResult FaveColor(string favecolor)
        {
            var AnonObject = new
            {
                FaveColor = favecolor
            };
            return Json (AnonObject);
        }

        [HttpGet]
        [Route("{firstname}/{lastname}/{age}/{favecolor}")]
        public JsonResult Display(string firstname, string lastname, int age, string favecolor)
        {
            var AnonObject = new
            {
                FirstName = firstname,
                LastName = lastname,
                Age = age,
                FaveColor = favecolor
            };
            return Json (AnonObject);
        }
    }
}
