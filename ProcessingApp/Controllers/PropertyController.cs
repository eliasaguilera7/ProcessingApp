using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessingApp.Data;
using ProcessingApp.Models;

namespace ProcessingApp.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public PropertyController(ApplicationDbContext context,
                                  IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }



        // GET: Property
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyModel.ToListAsync());
        }


        // GET: Property/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyModel
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (propertyModel == null)
            {
                return NotFound();
            }

            return View(propertyModel);
        }

        [Authorize]
        // GET: Property/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessingApp.ViewModels.PropertyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = null; 
                if(model.Image != null)
                {
                   string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                   uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                   string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                   model.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                }


                PropertyModel newPropertyModel = new PropertyModel
                {
                    PropertyId = model.PropertyId,
                    PropertyName = model.PropertyName,
                    PropertyAdress = model.PropertyAdress,
                    PropertyPrice = model.PropertyPrice,
                    City = model.City,
                    ImageUrl = uniqueFileName
                };

                _context.Add(newPropertyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                
            }
            return View();
        }
        
        // back up
        //       [HttpPost]
        //       [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("PropertyId,PropertyName,PropertyAdress,PropertyPrice,City")] PropertyModel propertyModel)
        /*        {
                    if (ModelState.IsValid)
                    {
                        _context.Add(propertyModel);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(propertyModel);
                }
        */


        [Authorize]
        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyModel.FindAsync(id);
            if (propertyModel == null)
            {
                return NotFound();
            }
            return View(propertyModel);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,PropertyName,PropertyAdress,PropertyPrice,City")] PropertyModel propertyModel)
        {
            if (id != propertyModel.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyModelExists(propertyModel.PropertyId))
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
            return View(propertyModel);
        }

        [Authorize]
        // GET: Property/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyModel = await _context.PropertyModel
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (propertyModel == null)
            {
                return NotFound();
            }

            return View(propertyModel);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyModel = await _context.PropertyModel.FindAsync(id);
            _context.PropertyModel.Remove(propertyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyModelExists(int id)
        {
            return _context.PropertyModel.Any(e => e.PropertyId == id);
        }
    }
}
