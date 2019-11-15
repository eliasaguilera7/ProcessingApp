using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessingApp.Data;
using ProcessingApp.Models;

namespace ProcessingApp.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Owner
        public async Task<IActionResult> Index()
        {
            return View(await _context.OwnerModel.ToListAsync());
        }

        // GET: Owner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerModel = await _context.OwnerModel
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (ownerModel == null)
            {
                return NotFound();
            }

            return View(ownerModel);
        }

        // GET: Owner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,OwnerName")] OwnerModel ownerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownerModel);
        }

        // GET: Owner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerModel = await _context.OwnerModel.FindAsync(id);
            if (ownerModel == null)
            {
                return NotFound();
            }
            return View(ownerModel);
        }

        // POST: Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerId,OwnerName")] OwnerModel ownerModel)
        {
            if (id != ownerModel.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerModelExists(ownerModel.OwnerId))
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
            return View(ownerModel);
        }

        // GET: Owner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerModel = await _context.OwnerModel
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (ownerModel == null)
            {
                return NotFound();
            }

            return View(ownerModel);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerModel = await _context.OwnerModel.FindAsync(id);
            _context.OwnerModel.Remove(ownerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerModelExists(int id)
        {
            return _context.OwnerModel.Any(e => e.OwnerId == id);
        }
    }
}
