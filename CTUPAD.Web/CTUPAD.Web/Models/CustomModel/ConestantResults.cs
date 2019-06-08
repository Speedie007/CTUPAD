using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.CustomModel
{
    public class ContestantResult
    {
        public int ContestantID { get; set; }
        public int CategoryID { get; set; }
        public double CategoryTotal { get; set; }
        public string ContestantFullName { get; set; }
        public string CategoryName { get; set; }
    }
}
