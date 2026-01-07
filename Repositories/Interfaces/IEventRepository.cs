using EventManagementSystem.Models;

namespace EventManagementSystem.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllUpcomingAsync();
        Task<Event?> GetByIdAsync(int id);
        Task AddAsync(Event evnt);
        Task UpdateAsync(Event evnt);
        Task DeleteAsync(int id);
    }
}
