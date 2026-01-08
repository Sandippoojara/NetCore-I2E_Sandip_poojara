using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Filters;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace NetCore_I2E_Sandip_poojara.Controllers
{
    [Route("events")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // Public
        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllUpcomingAsync();
            return View(events);
        }

        // Public
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _eventService.GetByIdAsync(id);
            if (eventDetails == null)
                return NotFound();

            return View(eventDetails);
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventManagementSystem.Models.Event model)
        {
            await _eventService.CreateEventAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Admin only (GET)
        [Authorize(Roles = "Admin")]
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var evnt = await _eventService.GetByIdAsync(id);
            if (evnt == null)
                return NotFound();

            return View(evnt);
        }

        // Admin only (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventManagementSystem.Models.Event model)
        {
            if (id != model.Id)
                return BadRequest();

            await _eventService.UpdateEventAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: events/delete/5
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _eventService.GetByIdAsync(id);
            if (eventDetails == null)
                return NotFound();

            return View(eventDetails); // returns Delete.cshtml
        }

        // POST: events/delete/5
        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
