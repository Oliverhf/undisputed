using Undisputed.Models;

namespace Undisputed.Interfaces
{
    public interface INeatTopicRepository
    {
        Task<IEnumerable<NeatTopic>> GetAll();
        Task<NeatTopic> GetByIdAsync(int id);
        Task<IEnumerable<NeatTopic>> GetNeatTopicByCity(string city);

        bool Add(NeatTopic neatTopic);
        bool Update(NeatTopic neatTopic);
        bool Delete(NeatTopic neatTopic);
        bool Save();
    }
}
