using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class OutptPresccript
    {
        public int OutptPresccriptId { get; set; }
        [ForeignKey("Appoinment")]
        public int AppoinmentId { get; set; }//for patientName
        public virtual Appoinment Appoinment { get; set; }
        public string MedicineName { get; set; }
        public string TestName { get; set; }
        public string Instruction { get; set; }
        public string Admitstatus { get; set; }
    }
}
