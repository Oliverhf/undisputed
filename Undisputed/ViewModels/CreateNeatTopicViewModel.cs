using Undisputed.Data.Enum;
using Undisputed.Models;

namespace Undisputed.ViewModels
{
    public class CreateNeatTopicViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public Address? Address { get; set; }
        public NeatTopicCategory NeatTopicCategory { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public DateTime? DateStarted { get; set; }
    }
}
