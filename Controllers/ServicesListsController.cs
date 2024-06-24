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
    public class ServicesListsController : Controller
    {
        private readonly ApplicationContext _context;

        public ServicesListsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ServicesLists
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ServicesLists.Include(s => s.Event).Include(s => s.Service);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ServicesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicesLists == null)
            {
                return NotFound();
            }

            var servicesList = await _context.ServicesLists
                .Include(s => s.Event)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.ServiceListId == id);
            if (servicesList == null)
            {
                return NotFound();
            }

            return View(servicesList);
        }

        // GET: ServicesLists/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: ServicesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceListId,EventId,ServiceId")] ServicesList servicesList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", servicesList.EventId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", servicesList.ServiceId);
            return View(servicesList);
        }

        // GET: ServicesLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicesLists == null)
            {
                return NotFound();
            }

            var servicesList = await _context.ServicesLists.FindAsync(id);
            if (servicesList == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", servicesList.EventId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", servicesList.ServiceId);
            return View(servicesList);
        }

        // POST: ServicesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceListId,EventId,ServiceId")] ServicesList servicesList)
        {
            if (id != servicesList.ServiceListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesListExists(servicesList.ServiceListId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", servicesList.EventId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", servicesList.ServiceId);
            return View(servicesList);
        }

        // GET: ServicesLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicesLists == null)
            {
                return NotFound();
            }

            var servicesList = await _context.ServicesLists
                .Include(s => s.Event)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.ServiceListId == id);
            if (servicesList == null)
            {
                return NotFound();
            }

            return View(servicesList);
        }

        // POST: ServicesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicesLists == null)
            {
                return Problem("Entity set 'ApplicationContext.ServicesLists'  is null.");
            }
            var servicesList = await _context.ServicesLists.FindAsync(id);
            if (servicesList != null)
            {
                _context.ServicesLists.Remove(servicesList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicesListExists(int id)
        {
          return _context.ServicesLists.Any(e => e.ServiceListId == id);
        }
    }
}
