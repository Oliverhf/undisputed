using Microsoft.EntityFrameworkCore;
using Undisputed.Data;
using Undisputed.Interfaces;
using Undisputed.Models;

namespace Undisputed.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Topic topic)
        {
            _context.Add(topic);
            return Save();
        }

        public bool Delete(Topic topic)
        {
            _context.Remove(topic);
            return Save();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.ToListAsync();
        }
        public async Task<IEnumerable<Topic>> GetAllByUser(string username)
        {
            return await _context.Topics.Where(t => t.AppUser.UserName == username).ToListAsync();
        }


        public async Task<Topic> GetByIdAsync(int id)
        {

            return await _context.Topics.Include(i => i.Address).FirstOrDefaultAsync(t => t.Id == id);
          
        }

        public async Task<Topic> GetByIdAsyncNoTracking(int id)
        {

            return await _context.Topics.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        }

        public async Task<IEnumerable<Topic>> GetTopicByCity(string city)
        {
            return await _context.Topics.Where(t => t.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }   

        public bool Update(Topic topic)
        {
            _context.Update(topic);
            return Save();
        }
    }
}
