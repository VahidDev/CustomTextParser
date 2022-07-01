using Microsoft.AspNetCore.Mvc;

namespace CustomTxtParser.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}