using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Appoinment
    {
        public int AppoinmentId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public DateTime AppointDate { get; set; }
        public string Problem { get; set; }
        public string SerialNo { get; set; }

        [ForeignKey("Doctors")]
        public int DoctorsId { get; set; }//for Doctorname
        public virtual Doctors Doctors { get; set; }
    }
}
