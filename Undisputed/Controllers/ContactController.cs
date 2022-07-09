using Microsoft.AspNetCore.Mvc;
using Undisputed.Interfaces;
using Undisputed.ViewModels;

namespace Undisputed.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMailService _mailService;

        public ContactController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Index(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("oliver.hfavalli@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message.Trim()}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            } 
            return View();
        }
    }
}
