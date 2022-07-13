using Microsoft.AspNetCore.Mvc;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.Repository;

namespace Undisputed.Controllers
{
    public class NeatTopicController : Controller
    {
        private readonly INeatTopicRepository _neatTopicRepository;

        public NeatTopicController(INeatTopicRepository neatTopicRepository)
        {
            _neatTopicRepository = neatTopicRepository;
        }
        public async  Task<IActionResult> Index()
        {
            IEnumerable<NeatTopic> neatTopics = await _neatTopicRepository.GetAll();
            return View(neatTopics);
        }
        public async Task<IActionResult> Detail(int id)
        {
            NeatTopic neatTopic = await _neatTopicRepository.GetByIdAsync(id);
            return View(neatTopic);
        }

    }
}
