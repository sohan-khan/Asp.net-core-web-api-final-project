using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class Bed
    {
        public int BedId { get; set; }//PK
        public int BedNo { get; set; }
        public string BedType { get; set; }
        public string BedCharge { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }//FK

        public virtual Room Room { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }
}
