using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Designation
    {
        public int designationId { get; set; }
        public string DesigRank { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
    }
}
