using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class InPtPrescription
    {
        public int InPtPrescriptionId { get; set; }
        [ForeignKey("Admission")]
        public int AddmisonId { get; set; }
        public bool IsReleased { get; set; }
        public virtual Admission Admission { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Instruction { get; set; }
        //public bool Relase { get; set; }
        
        public List<PntMedicine> PntMedicines { get; set; }
        public List<PatientTest> PatientTests { get; set; }
    }
}
