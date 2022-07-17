using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.Repository;
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

        public async Task<IActionResult> Edit(int id)
        {
            var topic = await _topicRepository.GetByIdAsync(id);
            if(topic == null) return View("Error");
            var topicVM = new EditTopicViewModel
            {
                Title = topic.Title,
                Description = topic.Description,
                AddressId = topic.AddressId,
                Address = topic.Address,
                URL = topic.Image,
                TopicCategory = topic.TopicCategory
            };
            return View(topicVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTopicViewModel topicVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Topic");
                return View("Edit", topicVM);
            }

            var userTopic = await _topicRepository.GetByIdAsyncNoTracking(id);

            if(userTopic != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userTopic.Image);
                }
                catch
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(topicVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(topicVM.Image);

                var topic = new Topic
                {
                    Id = id,
                    Title = topicVM.Title,
                    Description = topicVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = topicVM.AddressId,
                    Address = topicVM.Address,
                };

                _topicRepository.Update(topic);


                return RedirectToAction("Index");
            } else
            {
                return View(topicVM);
            }


        }


        public async Task<IActionResult> Delete(int id)
        {
            var topicDetails = await _topicRepository.GetByIdAsync(id);
            if (topicDetails == null) return View("Error");
            return View(topicDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topicDetails = await _topicRepository.GetByIdAsync(id);
            if (topicDetails == null) return View("Error");

            _topicRepository.Delete(topicDetails);
            return RedirectToAction("Index");
        }
      

        [Route("api/[Controller]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
