using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessingApp.Data;
using ProcessingApp.Models;

namespace ProcessingApp.Controllers
{
    public class MyApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int id)
        {
            String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // gameStoreUser = applicant 
            // Cart = MyApplication
            // CartItems = Applications
            // CartItem = ApplicationList
            // Carts = 
            var applicant = _context.Users.Include(user => user.MyApplication).Include(user => user.MyApplication.Applications)
                .Where(x => x.Id == userId).SingleOrDefault();

            if (applicant.MyApplication == null)
            {
                applicant.MyApplication = new MyApplication()
                {
                    Applications = new List<ApplicationList>()
                };
                _context.MyApplication.Add(applicant.MyApplication);
                _context.Update(applicant);

                _context.SaveChanges();
                _context.Update(applicant);
            }

            List<ApplicationList> items = applicant.MyApplication.Applications;
            if (items.Exists(x => x.PropertyId == id))
            {
                items.Where(x => x.PropertyId == id).SingleOrDefault();
            }
            else
            {
                ApplicationList al = new ApplicationList()
                {
                    PropertyId = id,
                    MyApplicationId = applicant.MyApplication.MyApplicationId,
                };
                //_context.Add(ci);
                items.Add(al);
            }
            _context.Update(applicant.MyApplication);
            _context.SaveChanges();
            return PartialView();
        }

        // GET: MyApplication
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyApplication.ToListAsync());
        }

        // GET: MyApplication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myApplication = await _context.MyApplication
                .FirstOrDefaultAsync(m => m.MyApplicationId == id);
            if (myApplication == null)
            {
                return NotFound();
            }

            return View(myApplication);
        }

        // GET: MyApplication/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyApplicationId")] MyApplication myApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myApplication);
        }

        // GET: MyApplication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myApplication = await _context.MyApplication.FindAsync(id);
            if (myApplication == null)
            {
                return NotFound();
            }
            return View(myApplication);
        }

        // POST: MyApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyApplicationId")] MyApplication myApplication)
        {
            if (id != myApplication.MyApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyApplicationExists(myApplication.MyApplicationId))
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
            return View(myApplication);
        }

        // GET: MyApplication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myApplication = await _context.MyApplication
                .FirstOrDefaultAsync(m => m.MyApplicationId == id);
            if (myApplication == null)
            {
                return NotFound();
            }

            return View(myApplication);
        }

        // POST: MyApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myApplication = await _context.MyApplication.FindAsync(id);
            _context.MyApplication.Remove(myApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyApplicationExists(int id)
        {
            return _context.MyApplication.Any(e => e.MyApplicationId == id);
        }
    }
}
