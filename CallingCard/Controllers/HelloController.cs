using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace calling_card.Controllers
{
    public class HelloController : Controller
    {
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
