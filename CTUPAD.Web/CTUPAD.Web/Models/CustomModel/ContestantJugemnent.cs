using CTUPAD.Web.Models.CustomModel;
using System;
using System.Collections.Generic;

namespace CTUPAD.Web.Models.CustomModel
{
    public partial class ContestantJugemnent
    {
        public int ContestantJugemnentID { get; set; }
        public int ContestantID { get; set; }
        public string JugeID { get; set; }
        public int CategoryID { get; set; }
        public int CategoryCriteariaID { get; set; }
        public double Rating { get; set; }

        public virtual Category Category { get; set; }
        public virtual CategoryCritearia CategoryCritearia { get; set; }
        public virtual Contestant Contestant { get; set; }
        public virtual ApplicationUser Juge { get; set; }
    }
}