using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Undisputed.Data;
using Undisputed.Extensions;
using Undisputed.Interfaces;
using Undisputed.Models;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashBoardRepository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashboardRepository = dashBoardRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }
        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.UserName = editVM.UserName;
            user.AboutMe = editVM.AboutMe.ToString();
            user.Score = editVM.Score;
            user.Rate = editVM.Rate;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = editVM.City;
            user.State = editVM.State;
  

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

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                UserName = user.UserName,
                AboutMe = user.AboutMe.ToString(),
                Score = user.Score,
                Rate = user.Rate,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State,
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            var user = await _dashboardRepository.GetUserByIdNoTracking(editVM.Id);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                } 
                catch(Exception ex)
                {
                    ModelState.AddModelError("", " Could not delete photo");
                    return View(editVM);
                }


                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);
                return RedirectToAction("Index");
            }
        }
    }
}
