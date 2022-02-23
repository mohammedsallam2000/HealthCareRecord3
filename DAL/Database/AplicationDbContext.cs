﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class AplicationDbContext : DbContext 
    {
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




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-5IGO47J; database = HCRDB; Integrated Security = true");
        }
    }
}
