using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Chelsea's Calling Card assignment! In the URL above, please input your first name, last name, age, and favorite color in this order.";
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