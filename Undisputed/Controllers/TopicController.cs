using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;

namespace Undisputed.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Topic> topics = await _topicRepository.GetAll();
            return View(topics);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Topic topic = await _topicRepository.GetByIdAsync(id);
            return View(topic);
        }
    }

}
