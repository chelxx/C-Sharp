using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace web_prac.Controllers
{
    public class HelloController : Controller
    {
        [HttpGetAttribute]
        public string Index()
        {
            return "Hello World!";
        }
    }
}