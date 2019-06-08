using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTUPAD.Web.Data;
using CTUPAD.Web.Models.CustomModel;
using CTUPAD.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CTUPAD.Web.Controllers
{
    public class ContestantResultsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ContestantResultsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            JudgeResultsViewModel model = new JudgeResultsViewModel();

            model.Categories = await _context.Categories.OrderBy(x => x.CategoryName).ToListAsync();
            model.SelectedCategoryName = model.Categories.First().CategoryName;
            if (model.Categories.Count > 0)
            {
                model.SelectedCategoryID = model.Categories.First().CategoryID;
                model.ContestantResults = await _context.ContestantResults
                    .OrderByDescending(x => x.CategoryTotal)
                    .Where(x => x.CategoryID == model.SelectedCategoryID)
                    .Take(5)
                    .ToListAsync();
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int CategoryID)
        {

            JudgeResultsViewModel model = new JudgeResultsViewModel();

            model.Categories = await _context.Categories.OrderBy(x => x.CategoryName).ToListAsync();
            model.SelectedCategoryID = CategoryID;

            model.ContestantResults = await _context.ContestantResults
                .OrderByDescending(x => x.CategoryTotal)
                .Where(x => x.CategoryID == CategoryID)
                .Take(5)
                .ToListAsync();
            model.SelectedCategoryName = model.Categories.Where(x => x.CategoryID == CategoryID).First().CategoryName;

            return View(model);
        }
    }
}