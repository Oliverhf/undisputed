namespace Undisputed.ViewModels
{
    public class EditUserDashboardViewModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public int? Score { get; set; }
        public int? Rate { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? City {get; set;}
        public string? State {get; set;}

        public string AboutMe {get; set;}
        public IFormFile? Image { get; set; }
    }
}
