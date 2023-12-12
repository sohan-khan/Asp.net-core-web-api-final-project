using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string ScheduleDays { get; set; }
        public string ScheduleTime { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorsId { get; set; }
        public virtual Doctors Doctors { get; set; }
      
    }
}
