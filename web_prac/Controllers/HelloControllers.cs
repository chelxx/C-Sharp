using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGetAttribute]
        public string Index()
        {
            return "Hello World! It is I!";
        }
    }
}