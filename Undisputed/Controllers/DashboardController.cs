using Microsoft.AspNetCore.Mvc;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashBoardRepository)
        {
            _dashboardRepository = dashBoardRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userTopics = await _dashboardRepository.GetAllUserTopics();
            var userNeatTopics = await _dashboardRepository.GetAllUserNeatTopics();
            var userTeams = await _dashboardRepository.GetAllUserTeams();

            var dashboardViewModel = new DashboardViewModel()
            {
                Topics = userTopics,
                NeatTopics = userNeatTopics,
                Teams = userTeams
            };

            return View(dashboardViewModel);
        }
    }
}
