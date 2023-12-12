using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Facilities
    {
        public int FacilitiesId { get; set; }
        [ForeignKey("Admission")]
        public int AddmisonId { get; set; }
        public virtual Admission Admission { get; set; }
        public string FacilityName { get; set; }
        public decimal FacilityPrice { get; set; }
    }
}
