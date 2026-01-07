using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using NetCore_I2E_Sandip_poojara.Data;
using NetCore_I2E_Sandip_poojara.Repositories.Interfaces;

namespace NetCore_I2E_Sandip_poojara.Repositories.Implementations
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Registration>> GetByUserIdAsync(string userId)
        {
            return await _context.Registrations
                .Include(r => r.Event)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }

      
    }
}
