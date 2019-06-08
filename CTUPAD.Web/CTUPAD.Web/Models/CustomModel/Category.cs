using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTUPAD.Web.Models.CustomModel
{
    public partial class Category
    {
        public Category()
        {
            CategoryCritearias = new HashSet<CategoryCritearia>();
            ContestantCategories = new HashSet<ContestantCategory>();
            ContestantJugemnents = new HashSet<ContestantJugemnent>();
        }

        [Display(Name = "Category Ref#")]
        public int CategoryID { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<CategoryCritearia> CategoryCritearias { get; set; }
        public virtual ICollection<ContestantCategory> ContestantCategories { get; set; }
        public virtual ICollection<ContestantJugemnent> ContestantJugemnents { get; set; }
    }
}