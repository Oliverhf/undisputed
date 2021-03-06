using Undisputed.Models;

namespace Undisputed.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAll();
        Task<IEnumerable<Topic>> GetAllByUser(string username);
        Task<Topic> GetByIdAsync(int id);
        Task<Topic> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Topic>> GetTopicByCity(string city);

        bool Add(Topic topic);
        bool Update(Topic topic);
        bool Delete(Topic topic);
        bool Save();

    }
}
