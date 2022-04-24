﻿using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PharmacistWorkServices
{
    public class PharmacistWorkServices : IPharmacistWorkServices
    {

        private readonly AplicationDbContext context;

        public PharmacistWorkServices(AplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<PharmacistWorkViewModel> GetAllOrders()
        {
            var Data = context.Treatment.Select(x => x);   
            List<PharmacistWorkViewModel> DataOfWaiting = new List<PharmacistWorkViewModel>();
            foreach (var item in Data)
            {
                if (item.State == false)
                {
                    PharmacistWorkViewModel obj = new PharmacistWorkViewModel();
                    obj.MedicineName = context.Medicine.Where(x => x.Id == item.MedicineId).Select(x => x.Name).FirstOrDefault();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    obj.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    obj.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    obj.TreatmentId = item.Id;
                    obj.OrderDateAndTime = item.OrderDateAndTime;
                    DataOfWaiting.Add(obj);
                }
            }
            return DataOfWaiting;
        }

        public PharmacistWorkViewModel GetByID(int id)
        {
            var treatment = context.Treatment.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            var DailyDetectionId = treatment.DailyDetectionId;
            var PatientId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
            var DoctorId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
            var DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(c => c.Name).FirstOrDefault();
            var PatientData = context.Patients.Where(x => x.Id == PatientId).Select(x => x).FirstOrDefault();
            PharmacistWorkViewModel obj = new PharmacistWorkViewModel();
            obj.PatientName = PatientData.Name;
            obj.SSN = PatientData.SSN;
            obj.Gender = PatientData.Gender;
            obj.Phone = PatientData.Phone;
            obj.Address = PatientData.Address;
            obj.DoctorName = DoctorName;
            obj.TreatmentId = treatment.Id;
            return obj;
        }

        public IEnumerable<PharmacistWorkViewModel> OrderDetails(int Id)
        {
            var PatientMedicineData = context.PatientMedicine.Where(x=>x.TreatmentId==Id).Select(x => x);
            
            List<PharmacistWorkViewModel> PatientMedicines = new List<PharmacistWorkViewModel>();
            foreach (var item in PatientMedicineData)
            {
                PharmacistWorkViewModel obj = new PharmacistWorkViewModel();
                var MedicineName = context.Medicine.Where(x => x.Id == item.MedicineId).Select(x => x.Name).FirstOrDefault();
                var Notes = context.Treatment.Where(x => x.Id == Id).Select(x => x.Notes).FirstOrDefault();
                obj.MedicineName = MedicineName;
                obj.Notes = Notes;
                PatientMedicines.Add(obj);
            }
            return PatientMedicines;
        }
    }
}
