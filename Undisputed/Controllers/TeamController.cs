using Microsoft.AspNetCore.Mvc;
using Undisputed.Data;
using Undisputed.Models;

namespace Undisputed.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList(); 
            return View(teams);
        }
    }
}
