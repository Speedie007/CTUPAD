using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.ViewModels
{
    public class ContestantEvaluationViewModel
    {

        public ContestantEvaluationViewModel()
        {

        }

        public int ContestantID { get; set; }
        public string ContestantFirstName { get; set; }
        public string ContestantLastName { get; set; }
        public string ContestantRating { get; set; }
    }
}
