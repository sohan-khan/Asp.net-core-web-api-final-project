using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Hospital_Management.Models.Context
{
    public class HospitalDbContext: DbContext
    {
        
        public HospitalDbContext(DbContextOptions<HospitalDbContext>options) : base(options)
        {
           
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<InPtPrescription>()
        //        .HasKey(nameof(InPtPrescription.FirstName), nameof(Actor.LastName));
        //}
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<OutptPresccript> OutptPresccripts { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<MedicineList> MedicineLists { get; set; }
        public DbSet<Testlist> Testlists { get; set; }
        public DbSet<InPtPrescription> InPtPrescriptions { get; set; }
        public DbSet<PntMedicine> PntMedicines { get; set; }
        public DbSet<PatientTest> PatientTests { get; set; }
        
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        
    }
}
