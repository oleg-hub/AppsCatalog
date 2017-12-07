using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppsCatalog.Data;
using AppsCatalog.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppsCatalog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AdministratorController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public AdministratorController(ApplicationDbContext context)  //write correct service for work with DB
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Applications.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .SingleOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application application)
        {
            if (ModelState.IsValid)
            {
                application = new Application
                {
                    Title = application.Title,
                    Сategory = application.Сategory,
                    Description = application.Description,
                    ApplicationUserName = User.Identity.Name
                };
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.SingleOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Application application)
        {
            application.ApplicationUserName = User.Identity.Name;
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
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
            return View(application);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .SingleOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var application = await _context.Applications.SingleOrDefaultAsync(m => m.Id == id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(string id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
