using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace PROG_POEDLL.Models
{
    public partial class SUser
    {
        public SUser()
        {
            Semesters = new HashSet<Semester>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
       



        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "Passwords IS INCORRECT")] 
        public string Password { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
