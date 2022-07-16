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

        public bool Add(NeatTopic neattopic)
        {
            _context.Add(neattopic);
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

        public async Task<NeatTopic> GetByIdAsync(int id)
        {
            return await _context.NeatTopics.Include(i => i.Address).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<NeatTopic> GetByIdAsyncNoTracking(int id)
        {
            return await _context.NeatTopics.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }


        public async Task<IEnumerable<NeatTopic>> GetNeatTopicByCity(string city)
        {
            return await _context.NeatTopics.Where(t => t.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(NeatTopic neattopic)
        {
            _context.Update(neattopic);
            return Save();
        }
    }

}
