using EventManagementSystem.Models;

namespace NetCore_I2E_Sandip_poojara.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task AddAsync(Registration registration);
        Task DeleteAsync(int id);
        
        
        Task<IEnumerable<Registration>> GetByUserIdAsync(string userId);
    }
}
