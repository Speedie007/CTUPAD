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
    public class CategoryCriteariasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryCriteariasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryCritearias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CategoryCritearias.Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CategoryCritearias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryCritearia = await _context.CategoryCritearias
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CategoryCriteariaID == id);
            if (categoryCritearia == null)
            {
                return NotFound();
            }

            return View(categoryCritearia);
        }

        // GET: CategoryCritearias/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: CategoryCritearias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryCriteariaID,CategoryID,CategoryCriteariaName")] CategoryCritearia categoryCritearia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryCritearia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", categoryCritearia.CategoryID);
            return View(categoryCritearia);
        }

        // GET: CategoryCritearias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryCritearia = await _context.CategoryCritearias.FindAsync(id);
            if (categoryCritearia == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", categoryCritearia.CategoryID);
            return View(categoryCritearia);
        }

        // POST: CategoryCritearias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryCriteariaID,CategoryID,CategoryCriteariaName")] CategoryCritearia categoryCritearia)
        {
            if (id != categoryCritearia.CategoryCriteariaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryCritearia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryCriteariaExists(categoryCritearia.CategoryCriteariaID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", categoryCritearia.CategoryID);
            return View(categoryCritearia);
        }

        // GET: CategoryCritearias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryCritearia = await _context.CategoryCritearias
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CategoryCriteariaID == id);
            if (categoryCritearia == null)
            {
                return NotFound();
            }

            return View(categoryCritearia);
        }

        // POST: CategoryCritearias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryCritearia = await _context.CategoryCritearias.FindAsync(id);
            _context.CategoryCritearias.Remove(categoryCritearia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryCriteariaExists(int id)
        {
            return _context.CategoryCritearias.Any(e => e.CategoryCriteariaID == id);
        }
    }
}
