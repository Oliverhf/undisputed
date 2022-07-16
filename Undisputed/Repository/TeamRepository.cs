using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;

namespace Undisputed.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Team team)
        {
            _context.Add(team);
            return Save();
        }

        public bool Delete(Team team)
        {
            _context.Remove(team);
            return Save();
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _context.Teams.Include(i => i.Address).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Team>> GetTopicByCity(string city)
        {
            return await _context.Teams.Where(t => t.Address.City.Contains(city)).ToListAsync();
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Team team)
        {
            _context.Update(team);
            return Save();
        }
    }
}
