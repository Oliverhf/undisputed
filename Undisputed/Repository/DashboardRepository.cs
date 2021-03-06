using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Extensions;
using Undisputed.Interfaces;
using Undisputed.Models;

namespace Undisputed.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<NeatTopic>> GetAllUserNeatTopics()
        {

            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userNeatTopics = _context.NeatTopics.Where(r => r.AppUser.Id == curUser);
            return userNeatTopics.ToList();
        }

        public async Task<List<Team>> GetAllUserTeams()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userTeams = _context.Teams.Where(r => r.AppUser.Id == curUser);
            return userTeams.ToList();
        }

        public async Task<List<Topic>> GetAllUserTopics()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userTopics = _context.Topics.Where(r => r.AppUser.Id == curUser);
            return userTopics.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {

            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
