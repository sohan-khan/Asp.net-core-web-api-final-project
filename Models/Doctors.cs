using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Doctors
    {
        public int DoctorsId { get; set; }
        public string DoctorName { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        
        public string DoctorType { get; set; }
        public int VisitFee { get; set; }
        public ICollection<Appoinment> Appoinments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }
}
