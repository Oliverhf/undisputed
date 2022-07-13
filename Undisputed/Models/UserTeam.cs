namespace Undisputed.Models
{
    public class UserTeam
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }

        public AppUser User { get; set; }
        public Team Team { get; set; }
    }
}
