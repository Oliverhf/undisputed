using Undisputed.Models;

namespace Undisputed.ViewModels
{
    public class DashboardViewModel
    {
        public List<Topic> Topics { get; set; }
        public List<NeatTopic> NeatTopics { get; set; }
        public List<Team> Teams { get; set; }
    }
}
