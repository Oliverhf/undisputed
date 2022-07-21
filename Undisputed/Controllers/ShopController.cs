using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undisputed.Models;

namespace Undisputed.Controllers
{
    public class ShopController : Controller
    {

        List<string> listOfProducts = new List<string>()
        {
            "T-shirt",
            "Mugs",
            "Caps",
        };

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/[Controller]/products")]

        public List<string> Products()
        {

            try
            {
                return listOfProducts;

            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

    }
}
