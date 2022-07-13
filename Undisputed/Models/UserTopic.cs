namespace Undisputed.Models
{
    public class UserTopic
    {
        public string UserId { get; set; }
        public int TopicId { get; set; }

        public AppUser User { get; set; }
        public Topic Topic { get; set; }
    }
}
