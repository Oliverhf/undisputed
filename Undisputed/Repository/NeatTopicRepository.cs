using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;

namespace Undisputed.Repository
{
    public class NeatTopicRepository : INeatTopicRepository
    {
        private readonly ApplicationDbContext _context;

        public NeatTopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(NeatTopic neatTopic)
        {
            _context.Add(neatTopic);
            return Save();
        }

        public bool Delete(NeatTopic neattopic)
        {
           _context.Remove(neattopic);
            return Save();
        }

        public async Task<IEnumerable<NeatTopic>> GetAll()
        {
            return await _context.NeatTopics.ToListAsync();
        }

        public async Task<IEnumerable<NeatTopic>> GetAllNeatTopicsByCity(string city)
        {
            return await _context.NeatTopics.Where(t => t.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<NeatTopic> GetByIdAsync(int id)
        {
            return await _context.NeatTopics.Include(i => i.Address).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(NeatTopic neatTopic)
        {
            _context.Update(neatTopic);
            return Save();
        }
    }

}
