using Microsoft.AspNetCore.Mvc;
using Undisputed.Interfaces;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach(var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Score = user.Score,
                    AboutMe = user.AboutMe,
                    Rate = user.Rate,
                    ProfileImageUrl = user.ProfileImageUrl.ToString(),
                };

                result.Add(userViewModel);
            }
            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                AboutMe = user.AboutMe,
                Score = user.Score,
                Rate = user.Rate,
                ProfileImageUrl = user.ProfileImageUrl.ToString(),
            };
            return View(userDetailViewModel);

        }
       

    }
}
