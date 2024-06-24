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
    public class ApplicationForEventsController : Controller
    {
        private readonly ApplicationContext _context;

        public ApplicationForEventsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ApplicationForEvents
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ApplicationsForEvents.Include(a => a.Customer).Include(a => a.EventType);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ApplicationForEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApplicationsForEvents == null)
            {
                return NotFound();
            }

            var applicationForEvent = await _context.ApplicationsForEvents
                .Include(a => a.Customer)
                .Include(a => a.EventType)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicationForEvent == null)
            {
                return NotFound();
            }

            return View(applicationForEvent);
        }

        // GET: ApplicationForEvents/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId");
            return View();
        }

        // POST: ApplicationForEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationId,SpaceDescription,DesiredStartDate,DesiredEndDate,DesiredStartTime,DesiredEndTime,ServicesDescription,OtherRequests,CustomerId,EventTypeId")] ApplicationForEvent applicationForEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationForEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", applicationForEvent.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", applicationForEvent.EventTypeId);
            return View(applicationForEvent);
        }

        // GET: ApplicationForEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApplicationsForEvents == null)
            {
                return NotFound();
            }

            var applicationForEvent = await _context.ApplicationsForEvents.FindAsync(id);
            if (applicationForEvent == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", applicationForEvent.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", applicationForEvent.EventTypeId);
            return View(applicationForEvent);
        }

        // POST: ApplicationForEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationId,SpaceDescription,DesiredStartDate,DesiredEndDate,DesiredStartTime,DesiredEndTime,ServicesDescription,OtherRequests,CustomerId,EventTypeId")] ApplicationForEvent applicationForEvent)
        {
            if (id != applicationForEvent.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationForEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationForEventExists(applicationForEvent.ApplicationId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", applicationForEvent.CustomerId);
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", applicationForEvent.EventTypeId);
            return View(applicationForEvent);
        }

        // GET: ApplicationForEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApplicationsForEvents == null)
            {
                return NotFound();
            }

            var applicationForEvent = await _context.ApplicationsForEvents
                .Include(a => a.Customer)
                .Include(a => a.EventType)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicationForEvent == null)
            {
                return NotFound();
            }

            return View(applicationForEvent);
        }

        // POST: ApplicationForEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApplicationsForEvents == null)
            {
                return Problem("Entity set 'ApplicationContext.ApplicationsForEvents'  is null.");
            }
            var applicationForEvent = await _context.ApplicationsForEvents.FindAsync(id);
            if (applicationForEvent != null)
            {
                _context.ApplicationsForEvents.Remove(applicationForEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationForEventExists(int id)
        {
          return _context.ApplicationsForEvents.Any(e => e.ApplicationId == id);
        }
    }
}
