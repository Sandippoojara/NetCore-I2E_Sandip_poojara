using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace EventManagementSystem.Controllers
{
    [Route("register")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // GET: /register/{eventId}
        [HttpGet("{eventId:int}")]
        public IActionResult Register(int eventId)
        {
            // Form to register user for event
            ViewBag.EventId = eventId;
            return View();
        }

        // POST: /register/{eventId}
        [HttpPost("{eventId:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(int eventId, string userId)
        {
            var registration = new Models.Registration
            {
                EventId = eventId,
                UserId = userId
            };

            await _registrationService.RegisterAsync(registration);
            return RedirectToAction("MyRegistrations");
        }

        // GET: /register/my
        [HttpGet("my")]
        public async Task<IActionResult> MyRegistrations(string userId)
        {
            var registrations = await _registrationService.GetUserRegistrationsAsync(userId);
            return View(registrations);
        }
    }
}
