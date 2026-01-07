using EventManagementSystem.Models;

namespace NetCore_I2E_Sandip_poojara.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllUpcomingAsync();
        Task<Event?> GetByIdAsync(int id);
        Task CreateEventAsync(Event evnt);
        Task UpdateEventAsync(Event evnt);
        Task DeleteEventAsync(int id);
    }
}
