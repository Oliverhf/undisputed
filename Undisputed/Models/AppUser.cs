using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Undisputed.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }

        public int? Score { get; set; }
        public int? Rate { get; set; }
        public string ProfileImageUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
        public string? City { get; set; }
        public string? State {get; set; }
        public string? AboutMe { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastActive { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public ICollection<Topic> Topics { get; set; }
        public ICollection<Topic> JoinedTopics { get; set; }
        public ICollection<NeatTopic> NeatTopics { get; set; }
        public ICollection<NeatTopic> JoinedNeatTopics { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Team> JoinedTeams { get; set; }
    }
}
