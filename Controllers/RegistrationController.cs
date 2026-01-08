using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;
using System.Security.Claims;

[Authorize]
[Route("register")]
public class RegistrationController : Controller
{
    private readonly IEventService _eventService;
    private readonly IRegistrationService _registrationService;

    public RegistrationController(IEventService eventService, IRegistrationService registrationService)
    {
        _eventService = eventService;
        _registrationService = registrationService;
    }

    [HttpGet("{eventId:int}")]
    public async Task<IActionResult> Register(int eventId)
    {
        var evnt = await _eventService.GetByIdAsync(eventId);

        if (evnt == null)
        {
            return NotFound();
        }

        return View(evnt); // ✅ pass event to view
    }

    [HttpPost("{eventId:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterConfirmed(int eventId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _registrationService.RegisterAsync(new Registration
        {
            EventId = eventId,
            UserId = userId
        });

        return RedirectToAction("Index", "Event");
    }
}
