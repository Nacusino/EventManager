using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationContext _context;

        public EventsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Events.Include(e => e.Application).Include(e => e.Employee).Include(e => e.Host).Include(e => e.Space);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Application)
                .Include(e => e.Employee)
                .Include(e => e.Host)
                .Include(e => e.Space)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationsForEvents, "ApplicationId", "ApplicationId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["HostId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "SpaceId", "SpaceId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,StartDate,EndDate,StartTime,EndTime,ReviewAfterEvent,GradeAfterEvent,ApplicationId,SpaceId,HostId,EmployeeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationsForEvents, "ApplicationId", "ApplicationId", @event.ApplicationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.EmployeeId);
            ViewData["HostId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.HostId);
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "SpaceId", "SpaceId", @event.SpaceId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationsForEvents, "ApplicationId", "ApplicationId", @event.ApplicationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.EmployeeId);
            ViewData["HostId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.HostId);
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "SpaceId", "SpaceId", @event.SpaceId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,StartDate,EndDate,StartTime,EndTime,ReviewAfterEvent,GradeAfterEvent,ApplicationId,SpaceId,HostId,EmployeeId")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            ViewData["ApplicationId"] = new SelectList(_context.ApplicationsForEvents, "ApplicationId", "ApplicationId", @event.ApplicationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.EmployeeId);
            ViewData["HostId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", @event.HostId);
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "SpaceId", "SpaceId", @event.SpaceId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Application)
                .Include(e => e.Employee)
                .Include(e => e.Host)
                .Include(e => e.Space)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationContext.Events'  is null.");
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return _context.Events.Any(e => e.EventId == id);
        }
    }
}
