using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.ViewModels
{
    public class ContestantViewModel
    {
        public string ContestantID { get; set; }

        public List<SelectListItem> Contestants { get; set; }
    }
}
