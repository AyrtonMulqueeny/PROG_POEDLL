using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace PROG_POEDLL.Models
{
    public partial class Module
    {
        public Module()
        {
            Sessions = new HashSet<Session>();
        }

        public int ModuleId { get; set; }
        public int SemesterId { get; set; }

        [Display(Name = "Module Code")] 
        public string Code { get; set; }

        [Display(Name = "Module Name")] 
        public string Name { get; set; }

        [Display(Name = "Weekly Hours")]
      /*meant to be a double not a decimal*/  public decimal HoursPerWeek { get; set; }

        [Display(Name = "Credits")] 
        public int Credit { get; set; }

        [Display(Name = "SelfStudyHours")]
        public decimal SelfStudyHours { get; set; }

        [NotMapped]
        [Display(Name = "Remaining Hours")]
        public double RemainingHours { get; set; }

        [NotMapped]
        public List<Session> sess { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
