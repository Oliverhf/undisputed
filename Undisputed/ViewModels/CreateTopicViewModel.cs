using Undisputed.Data.Enum;
using Undisputed.Models;

namespace Undisputed.ViewModels
{
    public class CreateTopicViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public Address? Address { get; set; }
        public TopicCategory TopicCategory { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public DateTime? DateStarted { get; set; }
    }
}
