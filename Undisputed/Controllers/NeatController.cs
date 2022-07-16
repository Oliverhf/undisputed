using Microsoft.AspNetCore.Mvc;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.Repository;
using Undisputed.Services;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class NeatController : Controller
    {
        private readonly INeatTopicRepository _neatTopicRepository;
        private readonly IPhotoService _photoService;

        public NeatController(INeatTopicRepository neatTopicRepository, IPhotoService photoService)
        {
            _neatTopicRepository = neatTopicRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<NeatTopic> neatTopics = await _neatTopicRepository.GetAll();
            return View(neatTopics);
        }
        public async Task<IActionResult> Detail(int id)
        {
            NeatTopic neatTopic = await _neatTopicRepository.GetByIdAsync(id);
            return View(neatTopic);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNeatTopicViewModel neatTopicVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(neatTopicVM.Image);
                var neatTopic = new NeatTopic
                {
                    Title = neatTopicVM.Title,
                    Description = neatTopicVM.Description,
                    Image = result.Url.ToString(),
                    NeatTopicCategory = neatTopicVM.NeatTopicCategory,
                    AppUserId = neatTopicVM.AppUserId,
                    Address = new Address
                    {
                        Street = neatTopicVM.Address.Street,
                        City = neatTopicVM.Address.City,
                        State = neatTopicVM.Address.State,
                    }
                };
                _neatTopicRepository.Add(neatTopic);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "NeatTopic creation failed");
            }

            return View(neatTopicVM);

        }


        [Route("api/[Controller]")]
        //[ApiController]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<NeatTopic>> Get()
        {
            try
            {
                return await _neatTopicRepository.GetAll();

            }
            catch (Exception ex)
            {
                return (IEnumerable<NeatTopic>)BadRequest("Failed to get NeatTopics");
            }

        }

        [HttpGet("api/[Controller]/{id:int}")]
        public async Task<NeatTopic> Get(int id)
        {
            try
{
                var neatTopic = await _neatTopicRepository.GetByIdAsync(id);

                if (neatTopic != null) return neatTopic;
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
