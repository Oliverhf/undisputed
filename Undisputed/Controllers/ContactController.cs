using Microsoft.AspNetCore.Mvc;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            return View();
        }
    }
}
