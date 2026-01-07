using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace EventManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: /Admin/Events
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllUpcomingAsync();
            return View(events);
        }

        // Admin-specific actions (Create/Edit/Delete) will go here
    }
}
