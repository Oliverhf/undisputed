using Microsoft.AspNetCore.Mvc;

namespace RunGroopWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("PageServerError");
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}