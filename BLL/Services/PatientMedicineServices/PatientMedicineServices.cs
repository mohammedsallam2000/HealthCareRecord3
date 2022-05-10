using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientMedicineServices
{
   
    public class PatientMedicineServices : IPatientMedicineServices
    {
        private readonly AplicationDbContext context;
        public PatientMedicineServices(AplicationDbContext context)
        {
            this.context = context;
        }

        public bool Add(string[] Medicine, string Document, int DailyDetectionId)
        {
            Treatment obj=new Treatment();
            obj.Notes = Document;
            obj.DailyDetectionId= DailyDetectionId;
            obj.OrderDateAndTime = DateTime.Now;
            context.Treatment.Add(obj);
            context.SaveChanges();
            foreach (var item in Medicine)
            {
                if (item != null)
                {
                    PatientMedicine a = new PatientMedicine();

                    a.MedicineId = context.Medicine.Where(x => x.Name == item).Select(x => x.Id).FirstOrDefault();
                    a.TreatmentId = obj.Id;

                    context.PatientMedicine.Add(a);
                }
               


            }
            context.SaveChanges();
            return true;
        }

        public IEnumerable<PatientMedicineViewModel> GetAll(int id)
        {
            try
            {
                return context.PatientMedicine
                                .Where(x => x.State == true /*&& x.PatientId == id*/)
                                       .Select(x => new PatientMedicineViewModel
                                       {
                                           Id = x.Id,
                                           //PatientId = x.PatientId,
                                           //DoctorId = x.DoctorId,
                                           MedicineName = context.Medicine.Where(y => y.Id == x.MedicineId).Select(y => y.Name).FirstOrDefault(),
                                           //DateAndTime = x.DateAndTime,
                                           
                                       }); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<PatientMedicineViewModel> GetAllUnActive(int id)
        {
            throw new NotImplementedException();
        }
    }
}
