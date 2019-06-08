using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTUPAD.Web.Models.CustomModel
{
    public partial class Contestant
    {
        public Contestant()
        {
            ContestantCategories = new HashSet<ContestantCategory>();
            ContestantJugemnents = new HashSet<ContestantJugemnent>();
        }

        public int ContestantID { get; set; }
        [Display(Name ="First Name")]
        public string ContestantFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string ContestantLastName { get; set; }

        public virtual ICollection<ContestantCategory> ContestantCategories { get; set; }
        public virtual ICollection<ContestantJugemnent> ContestantJugemnents { get; set; }

        public string FullName => $"{ContestantFirstName} {ContestantLastName}";
    }
}