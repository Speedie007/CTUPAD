using System;
using System.Collections.Generic;

namespace CTUPAD.Web.Models.CustomModel
{
    public partial class ContestantCategory
    {
        public int ContestCategoryID { get; set; }
        public int ContestantID { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Contestant Contestant { get; set; }
    }
}