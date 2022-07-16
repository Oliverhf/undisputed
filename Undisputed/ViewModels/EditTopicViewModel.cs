using Undisputed.Data.Enum;
using Undisputed.Models;

namespace Undisputed.ViewModels
{
    public class EditTopicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int? AddressId { get; set; }
        public string? URL { get; set; }
        public IFormFile Image { get; set; }
        public TopicCategory TopicCategory { get; set; }
    }
}
