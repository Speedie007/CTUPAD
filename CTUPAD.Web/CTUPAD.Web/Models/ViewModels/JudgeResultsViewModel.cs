using CTUPAD.Web.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.ViewModels
{
    public class JudgeResultsViewModel
    {

        public JudgeResultsViewModel()
        {
            Categories = new List<Category>();
            ContestantResults = new List<ContestantResult>();
        }

        public int SelectedCategoryID { get; set; }
        public string SelectedCategoryName { get; set; }
        public List<Category> Categories { get; set; }

        public List<ContestantResult> ContestantResults { get; set; }
    }
}
