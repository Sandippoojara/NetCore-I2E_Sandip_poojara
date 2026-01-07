using EventManagementSystem.Models;
using EventManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NetCore_I2E_Sandip_poojara.Data;

namespace NetCore_I2E_Sandip_poojara.Repositories.Implementations
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllUpcomingAsync()
        {
            return await _context.Events
                .Where(e => e.EventDate >= DateTime.Now)
                .OrderBy(e => e.EventDate)
                .ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Registrations)
                .FirstOrDefaultAsync(e => e.Id == id); 
        }

        public async Task AddAsync(Event evnt)
        {
            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event evnt)
        {
            _context.Events.Update(evnt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt != null)
            {
                _context.Events.Remove(evnt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
