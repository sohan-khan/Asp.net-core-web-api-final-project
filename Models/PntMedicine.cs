using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class PntMedicine
    {
        public int PntMedicineId { get; set; }
        [ForeignKey("InPtPrescription")]
        public int InPtPrescriptionId { get; set; }
        [ForeignKey("MedicineList")]
        public int MedicineListId { get; set; }
        public int Quantity { get; set; }
        public string Doges { get; set; }
        public virtual InPtPrescription InPtPrescription { get; set; }
        public virtual MedicineList MedicineList { get; set; }


    }
}
