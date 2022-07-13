using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Undisputed.Data.Enum;

namespace Undisputed.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }
        public TopicCategory TopicCategory { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public ICollection<AppUser> Users { get; set; }

        public DateTime? DateStarted { get; set; } = DateTime.Now;
    }
}
