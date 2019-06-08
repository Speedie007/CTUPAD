
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTUPAD.Web.Models.CustomModel
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ContestantJugemnents = new HashSet<ContestantJugemnent>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ContestantJugemnent> ContestantJugemnents { get; set; }

    }
}
