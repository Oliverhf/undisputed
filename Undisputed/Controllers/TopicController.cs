using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPhotoService _photoService;

        public TopicController(ITopicRepository topicRepository, IPhotoService photoService)
        {
            _topicRepository = topicRepository;
            _photoService = photoService;
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

  
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicViewModel topicVM)
        {
            if(ModelState.IsValid)
            {

                var result = await _photoService.AddPhotoAsync(topicVM.Image);

                var topic = new Topic
                {
                    Title = topicVM.Title,
                    Description = topicVM.Description,
                    Image = result.Url.ToString(),
                    TopicCategory = topicVM.TopicCategory,
                    AppUserId = topicVM.AppUserId,
                    Address = new Address
                    {
                        Street = topicVM.Address.Street,
                        City = topicVM.Address.City,
                        State = topicVM.Address.State,
                    }
                };

                _topicRepository.Add(topic);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Topic creation failed");
            }
            
            return View(topicVM);
            
        }



        [Route("api/[Controller]")]
        //[ApiController]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<Topic>> Get()
        {

            try
            {
                return await _topicRepository.GetAll();

            }
            catch (Exception ex)
            {
                return (IEnumerable<Topic>)BadRequest("Failed to get topics");
            }

        }

        [HttpGet("api/[Controller]/{id:int}")]
        public async Task<Topic> Get(int id)
        {
            try
            {
               var topic = await _topicRepository.GetByIdAsync(id);

                if (topic != null) return topic;
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
