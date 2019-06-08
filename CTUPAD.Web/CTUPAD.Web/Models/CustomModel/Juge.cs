using System;
using System.Collections.Generic;

namespace CTU.Models.CustomModel
{
    public partial class Juge
    {
        public Juge()
        {
            ContestantJugemnents = new HashSet<ContestantJugemnent>();
        }

        public int JugeID { get; set; }
        public string JugeFisrtName { get; set; }
        public string JugeLastName { get; set; }

        public virtual ICollection<ContestantJugemnent> ContestantJugemnents { get; set; }
    }
}