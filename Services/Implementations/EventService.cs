using EventManagementSystem.Models;
using EventManagementSystem.Repositories.Interfaces;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace NetCore_I2E_Sandip_poojara.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;

        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        //GetAllUpcomingAsync
        public async Task<IEnumerable<Event>> GetAllUpcomingAsync()
        {
            return await _eventRepo.GetAllUpcomingAsync();
        }
        //GetByIdAsync
        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _eventRepo.GetByIdAsync(id);
        }
        //CreateEventAsync
        public async Task CreateEventAsync(Event evnt)
        {
            await _eventRepo.AddAsync(evnt);
        }
        //UpdateEventAsync
        public async Task UpdateEventAsync(Event evnt)
        {
            await _eventRepo.UpdateAsync(evnt);
        }
        //DeleteEventAsync
        public async Task DeleteEventAsync(int id)
        {
            await _eventRepo.DeleteAsync(id);
        }

    }
}
