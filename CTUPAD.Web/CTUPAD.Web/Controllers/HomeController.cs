using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CTUPAD.Web.Models;
using CTUPAD.Web.Models.ViewModels;
using CTUPAD.Web.Data;
using Microsoft.EntityFrameworkCore;
using CTUPAD.Web.Models.CustomModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CTUPAD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly HttpContext _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        public IActionResult Index()
        {

            return View();
        }
        [Authorize]
        public async Task<IActionResult> JudgePage()
        {
            JugdeEvaluationViewModel model = new JugdeEvaluationViewModel();

            model.ListOfCategories = await _context.Categories.ToListAsync();
            foreach (Contestant con in await _context.Contestants.ToListAsync())
            {
                model.Contestants.Add(new SelectListItem
                {
                    Value = con.ContestantID.ToString(),
                    Text = con.FullName
                });
            }
            model.JudgeID = _userManager.GetUserId(User);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCategoryCriteria([FromBody] List<ContestantJugemnent> model)
        {
            foreach (var item in model)
            {
                var x = await _context.ContestantJugemnents.Where(
                    a => a.ContestantID == item.ContestantID &&
                    a.JugeID == item.JugeID &&
                    a.CategoryCriteariaID == item.CategoryCriteariaID).FirstOrDefaultAsync();
                if (x == null)
                {
                    await _context.ContestantJugemnents.AddAsync(new ContestantJugemnent()
                    {
                        ContestantID = item.ContestantID,
                        JugeID = item.JugeID,
                        CategoryID = item.CategoryID,
                        CategoryCriteariaID = item.CategoryCriteariaID,
                        Rating = item.Rating
                    });
                    
                }
                else
                {
                    x.Rating = item.Rating;
                    await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();
            return new JsonResult("Passed");
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryCriteria([FromBody] ContestantJugemnent Rtn)
        {
            List<ContestantCirteriaViewModel> ContestantCriteriaList = new List<ContestantCirteriaViewModel>();

            List<ContestantCirteriaViewModel> x = await (from a in _context.CategoryCritearias
                                                         where a.CategoryID == Rtn.CategoryID
                                                         select new ContestantCirteriaViewModel
                                                         {
                                                             CategoryCriteariaID = a.CategoryCriteariaID,
                                                             CategoryCriteariaName = a.CategoryCriteariaName,
                                                             Rating = 0
                                                         }).ToListAsync();

            List<ContestantJugemnent> CurrentJudgements = await
                _context.ContestantJugemnents
                .Where(b => b.ContestantID == Rtn.ContestantID &&
                b.JugeID == Rtn.JugeID &&
                 b.CategoryID == Rtn.CategoryID).ToListAsync();

            foreach (ContestantCirteriaViewModel CCVM in x)
            {
                ContestantJugemnent JudgedItem = CurrentJudgements
                    .Where(c => c.CategoryCriteariaID == CCVM.CategoryCriteariaID &&
                     c.ContestantID == Rtn.ContestantID)
                    .FirstOrDefault();

                if (JudgedItem != null)
                {
                    CCVM.Rating = JudgedItem.Rating;
                }
            }

            return new JsonResult(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ContestantCriteriaReturnModel
    {
        public int ContestantID { get; set; }
        public string JugeID { get; set; }

    }
}
