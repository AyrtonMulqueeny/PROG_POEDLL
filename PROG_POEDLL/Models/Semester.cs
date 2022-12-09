using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace PROG_POEDLL.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Modules = new HashSet<Module>();
        }

        public int SemesterId { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Semester Lenght (Weeks)")] 
        public int NumberOfWeeks { get; set; }

        public virtual SUser User { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
