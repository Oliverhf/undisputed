using Undisputed.Models;

namespace Undisputed.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
