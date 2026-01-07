using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;
using System.Security.Claims;

namespace EventManagementSystem.Controllers
{
    [Authorize]
    [Route("register")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IEventService _eventService;

        public RegistrationController(
            IRegistrationService registrationService,
            IEventService eventService)
        {
            _registrationService = registrationService;
            _eventService = eventService;
        }

        // GET: /register/{eventId}
        [HttpGet("{eventId:int}")]
        public async Task<IActionResult> Register(int eventId)
        {
            var evnt = await _eventService.GetByIdAsync(eventId);
            if (evnt == null)
                return NotFound();

            ViewBag.EventId = eventId;
            ViewBag.EventTitle = evnt.Title;

            return View();
        }

        // POST: /register/{eventId}
        [HttpPost("{eventId:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterConfirmed(int eventId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _registrationService.RegisterAsync(new Models.Registration
            {
                EventId = eventId,
                UserId = userId
            });

            return RedirectToAction(nameof(MyRegistrations));
        }

        // GET: /register/my
        [HttpGet("my")]
        public async Task<IActionResult> MyRegistrations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var registrations = await _registrationService
                .GetUserRegistrationsAsync(userId!);

            return View(registrations);
        }
    }
}
