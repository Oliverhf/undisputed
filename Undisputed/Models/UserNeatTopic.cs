namespace Undisputed.Models
{
    public class UserNeatTopic
    {
        public string UserId { get; set; }
        public int NeatTopicId { get; set; }

        public AppUser User { get; set; }
        public NeatTopic NeatTopic { get; set; }
    }
}
