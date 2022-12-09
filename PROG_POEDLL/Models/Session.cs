using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PROG_POEDLL.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int ModuleId { get; set; }
        
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }

        public virtual Module Module { get; set; }
    }
}
