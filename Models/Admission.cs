using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Admission
    {
        public int AdmissionId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime AddmissionDate { get; set; }

        public string Problem { get; set; }
        
        public bool IsRelase { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorsId { get; set; }
        public Doctors Doctors { get; set; }

        [ForeignKey("Bed")]
        public int BedId { get; set; }
        public virtual Bed Bed { get; set; }
        public int OutptPresccriptId { get; set; }
    }
}
