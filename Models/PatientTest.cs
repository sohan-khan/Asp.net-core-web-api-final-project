using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class PatientTest
    {
        public int PatientTestId { get; set; }
        [ForeignKey("InPtPrescription")]
        public int InPtPrescriptionId { get; set; }
        public virtual InPtPrescription InPtPrescription { get; set; }
        [ForeignKey("Testlist")]
        public int TestlistId { get; set; }
        public virtual Testlist Testlist { get; set; }
        public string Result { get; set; }
    }
}
