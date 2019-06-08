using CTUPAD.Web.Models.CustomModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.ViewModels
{
    public class JugdeEvaluationViewModel
    {
        public JugdeEvaluationViewModel()
        {
            ListOfCategories = new List<Category>();
            Contestants = new List<SelectListItem>();
        }
        public string JudgeID { get; set; }
        public List<Category> ListOfCategories { get; set; }
        public string ContestantID { get; set; }
        public List<SelectListItem> Contestants { get; set; }
    }
}
