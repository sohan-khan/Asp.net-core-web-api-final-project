using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Testlist
    {
        public int testlistId { get; set; }
        public string TestName { get; set; }
        public decimal Price { get; set; }


        public ICollection<PatientTest> PatientTests { get; set; }

    }
}
