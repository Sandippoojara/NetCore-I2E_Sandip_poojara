using EventManagementSystem.Models;

namespace NetCore_I2E_Sandip_poojara.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetUserRegistrationsAsync(string userId);
        Task RegisterAsync(Registration registration);
    }
}
