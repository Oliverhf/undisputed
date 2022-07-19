using Undisputed.Models;

namespace Undisputed.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Topic>> GetAllUserTopics();
        Task<List<NeatTopic>> GetAllUserNeatTopics();
        Task<List<Team>> GetAllUserTeams();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetUserByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
