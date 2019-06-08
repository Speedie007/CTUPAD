using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTUPAD.Web.Models.CustomModel
{
    public partial class CategoryCritearia
    {
        public CategoryCritearia()
        {
            ContestantJugemnents = new HashSet<ContestantJugemnent>();
        }

        public int CategoryCriteariaID { get; set; }
        public int CategoryID { get; set; }
        [Display(Name = "Criteria")]
        public string CategoryCriteariaName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ContestantJugemnent> ContestantJugemnents { get; set; }
    }
}