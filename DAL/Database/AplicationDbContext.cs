using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class AplicationDbContext : IdentityDbContext 
    {
        //public AplicationDbContext()
        //{
        //}

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Emplyee> Emplyees { get; set; }
        public DbSet<Lab> Lab { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Radiology> Radiology { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Surgery> Surgery { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<PatientOfDoctor> PatientOfDoctor { get; set; }
        public DbSet<PatientLab> PatientLab { get; set; }
        public DbSet<PatientOfNurse> PatientOfNurse { get; set; }
        public DbSet<PatientRediology> PatientRediology { get; set; }
        public DbSet<PatientRoom> PatientRoom { get; set; }
        public DbSet<DailyDetection> DailyDetection { get; set; }
        public DbSet<Room> Room { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Emplyee>(entity => {
        //        entity.HasIndex(e => e.SSN).IsUnique();
        //    });
        //}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = .; database = HealthCareRecordDB; Integrated Security = true");
        //}
        //protected override void OnModelCreating(ModelBuilder builder)

        //{
        //    //// To Make more than one primary key
        //    //builder.Entity<DailyDetection>()
        //    //    .HasKey(k => new { k.Id, k.DateAndTime })
        //    //    .HasName("DailyDetection_PK");
        //    //base.OnModelCreating(builder);
        //}
    }
}
