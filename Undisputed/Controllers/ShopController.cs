using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Undisputed.Controllers
{
    public class ShopController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
