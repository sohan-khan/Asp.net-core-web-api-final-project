using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class PaymentDetails
    {
        public int PaymentDetailsId { get; set; }
        [ForeignKey("Admission")]
        public int AdmissionId { get; set; }

        public int FacilitiesId { get; set; }
        public int PatientTestId { get; set; }
        public int PatientMedicineId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Payment { get; set; }
        public decimal Due { get; set; }
        public decimal NetPayment { get; set; }
        public virtual Admission Admission { get; set; }
    }
}
