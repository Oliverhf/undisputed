using Microsoft.AspNetCore.Mvc;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.Repository;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Team> teams =  await _teamRepository.GetAll(); 
            return View(teams);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Team team = await _teamRepository.GetByIdAsync(id);
            return View(team);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamViewModel teamVM)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    Title = teamVM.Title,
                    Description = teamVM.Description,
                    Image = teamVM.Image.ToString(),
                    TeamCategory = teamVM.TeamCategory,
                    AppUserId = teamVM.AppUserId,
                    Address = new Address
                    {
                        Street = teamVM.Address.Street,
                        City = teamVM.Address.City,
                        State = teamVM.Address.State,
}
};
                _teamRepository.Add(team);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Team creation failed");
            }

            return View(teamVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teamDetails = await _teamRepository.GetByIdAsync(id);
            if (teamDetails == null) return View("Error");
            return View(teamDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var teamDetails = await _teamRepository.GetByIdAsync(id);
            if (teamDetails == null) return View("Error");

            _teamRepository.Delete(teamDetails);
            return RedirectToAction("Index");
        }



        [Route("api/[Controller]")]
        //[ApiController]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            try
            {
                return await _teamRepository.GetAll();

            }
            catch (Exception ex)
            {
                return (IEnumerable<Team>)BadRequest("Failed to get teams");
            }

        }

        [HttpGet("api/[Controller]/{id:int}")]
        public async Task<Team> Get(int id)
        {
            try
{
                var team = await _teamRepository.GetByIdAsync(id);

                if (team != null) return team;
                //NotFound();
                else return null;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
