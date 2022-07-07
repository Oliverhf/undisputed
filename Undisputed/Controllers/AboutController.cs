using Microsoft.AspNetCore.Mvc;

namespace Undisputed.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
