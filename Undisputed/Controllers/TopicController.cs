using Microsoft.AspNetCore.Mvc;

namespace Undisputed.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
