using Undisputed.Models;

namespace Undisputed.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetTopicByCity(string city);

        bool Add(Team team);
        bool Update(Team team);
        bool Delete(Team team);
        bool Save();
    }
}
