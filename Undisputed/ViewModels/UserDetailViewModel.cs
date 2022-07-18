namespace Undisputed.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? Score { get; set; }
        public int? Posts { get; set; }
        public int? Rate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? AboutMe { get; set; }
    }
}
