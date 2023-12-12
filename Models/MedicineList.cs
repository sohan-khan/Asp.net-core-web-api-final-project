using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management.Models
{
    public class MedicineList
    {
        public int MedicineListId { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public ICollection<MedicineList> MedicineLists { get; set; }
    }
}
