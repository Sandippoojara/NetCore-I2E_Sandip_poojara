using EventManagementSystem.Models;
using NetCore_I2E_Sandip_poojara.Repositories.Interfaces;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace NetCore_I2E_Sandip_poojara.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepo;
        public RegistrationService(IRegistrationRepository registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        public Task<IEnumerable<Registration>> GetUserRegistrationsAsync(string userId)
         => _registrationRepo.GetByUserIdAsync(userId);

        public Task RegisterAsync(Registration registration)
            => _registrationRepo.AddAsync(registration);

    }
}
