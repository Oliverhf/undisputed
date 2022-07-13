using Microsoft.AspNetCore.Mvc;

namespace Undisputed.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
