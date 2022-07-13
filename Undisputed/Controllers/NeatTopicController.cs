using Microsoft.AspNetCore.Mvc;

namespace Undisputed.Controllers
{
    public class NeatTopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
