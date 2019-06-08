using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using CTUPAD.Web.Data;
using CTUPAD.Web.Models.CustomModel;
using Microsoft.AspNetCore.Authorization;

namespace CTUPAD.Web.Controllers
{
    [Authorize]
    public class ContestantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContestantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contestants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contestants.ToListAsync());
        }

        // GET: Contestants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants
                .FirstOrDefaultAsync(m => m.ContestantID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // GET: Contestants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contestants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContestantID,ContestantFirstName,ContestantLastName")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contestant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contestant);
        }

        // GET: Contestants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants.FindAsync(id);
            if (contestant == null)
            {
                return NotFound();
            }
            return View(contestant);
        }

        // POST: Contestants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContestantID,ContestantFirstName,ContestantLastName")] Contestant contestant)
        {
            if (id != contestant.ContestantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contestant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestantExists(contestant.ContestantID))
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
            return View(contestant);
        }

        // GET: Contestants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants
                .FirstOrDefaultAsync(m => m.ContestantID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // POST: Contestants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contestant = await _context.Contestants.FindAsync(id);
            _context.Contestants.Remove(contestant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestantExists(int id)
        {
            return _context.Contestants.Any(e => e.ContestantID == id);
        }
    }
}
