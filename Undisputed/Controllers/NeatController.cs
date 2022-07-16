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


        public async Task<IActionResult> Edit(int id)
        {
            var neatTopic = await _neatTopicRepository.GetByIdAsync(id);
            if (neatTopic == null) return View("Error");
            var neatTopicVM = new EditNeatTopicViewModel
            {
                Title = neatTopic.Title,
                Description = neatTopic.Description,
                AddressId = neatTopic.AddressId,
                Address = neatTopic.Address,
                URL = neatTopic.Image,
                NeatTopicCategory = neatTopic.NeatTopicCategory
            };
            return View(neatTopicVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditNeatTopicViewModel neatTopicVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Neat Topic");
                return View("Edit", neatTopicVM);
            }

            var userNeatTopic = await _neatTopicRepository.GetByIdAsyncNoTracking(id);

            if (userNeatTopic != null)
            {
                try
                {
                    var fi = new FileInfo(userNeatTopic.Image);
                    var publicId = Path.GetFileNameWithoutExtension(fi.Name);
                    await _photoService.DeletePhotoAsync(publicId);
                }
                catch
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(neatTopicVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(neatTopicVM.Image);

                var neatTopic = new NeatTopic
                {
                    Id = id,
                    Title = neatTopicVM.Title,
                    Description = neatTopicVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = neatTopicVM.AddressId,
                    Address = neatTopicVM.Address,
                };

                _neatTopicRepository.Update(neatTopic);


                return RedirectToAction("Index");
            }
            else
            {
                return View(neatTopicVM);
            }


        }

        public async Task<IActionResult> Delete(int id)
        {
            var neatTopicDetails = await _neatTopicRepository.GetByIdAsync(id);
            if (neatTopicDetails == null) return View("Error");
            return View(neatTopicDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNeat(int id)
        {
            var neatDetails = await _neatTopicRepository.GetByIdAsync(id);
            if (neatDetails == null) return View("Error");

            _neatTopicRepository.Delete(neatDetails);
            return RedirectToAction("Index");
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
