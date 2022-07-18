using Undisputed.Models;

namespace Undisputed.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Topic>> GetAllUserTopics();
        Task<List<NeatTopic>> GetAllUserNeatTopics();
        Task<List<Team>> GetAllUserTeams();
    }
}
