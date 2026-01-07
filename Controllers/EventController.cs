using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_I2E_Sandip_poojara.Data;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;

namespace NetCore_I2E_Sandip_poojara.Controllers
{
    [Route("events")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventService _eventService;
        public EventController(ApplicationDbContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;

        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllUpcomingAsync();
            return View(events);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _eventService.GetByIdAsync(id);
            if (eventDetails == null)
            {
                return NotFound();
            }
            return View(eventDetails);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventManagementSystem.Models.Event model)
        {
            if (ModelState.IsValid)
            {
                await _eventService.CreateEventAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        // GET: /edit/5
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(EventManagementSystem.Models.Event model)
        {
            await _eventService.UpdateEventAsync(model);
            //if (eventToEdit == null)
            //{
            //    return NotFound();
            //}
            return RedirectToAction(nameof(Index));
        }

        // POST: /edit/5
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventManagementSystem.Models.Event model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _eventService.UpdateEventAsync(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /delete/5
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteEventAsync(id);
           // if (eventToDelete == null)
           // {
           //     return NotFound();
           // }
            return RedirectToAction(nameof(Index));
        }

        // POST: /delete/5
        [HttpPost("delete/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventToDelete = await _eventService.GetByIdAsync(id);
            if (eventToDelete != null)
            {
                await _eventService.DeleteEventAsync(eventToDelete.Id);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }


    }
}
