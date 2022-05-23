using AutoMapper;
using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.MedicineServices
{
    public class MedicineServices : IMedicineServices
    {
        #region Fiels
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public MedicineServices(AplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        #endregion

        #region Create Medicine
        public bool Add(MedicineViewModel medicine)
        {
            var data = db.Medicine.Where(r => r.Name == medicine.Name).ToList();
            if (data == null || data.Count == 0)
            {
                var a = mapper.Map<Medicine>(medicine);
                db.Medicine.Add(a);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Get All Medicines
        public IEnumerable<MedicineViewModel> GetAll()
        {
            List<MedicineViewModel> list = new List<MedicineViewModel>();
            foreach (var item in db.Medicine)
            {
                var data = mapper.Map<MedicineViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        #endregion

        #region Get All Medicines carried out
        public IEnumerable<MedicineViewModel> GetAllEnd()
        {
            List<MedicineViewModel> list = new List<MedicineViewModel>();
            foreach (var item in db.Medicine.Where(x => x.Count == 0))
            {
                var data = mapper.Map<MedicineViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        #endregion

        #region Get All Treatment
        public IEnumerable<TreatmentViewModel> GetAllTreatment(int id)
        {
            try
            {
                List<TreatmentViewModel> lit = new List<TreatmentViewModel>();
                var data = db.Treatment
                                 .Where(x => x.Id > 0 && (db.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(a => a.PatientId).FirstOrDefault()) == id);

                foreach (var item in data)
                {
                    TreatmentViewModel obj = new TreatmentViewModel();
                    obj.Id = item.Id;
                    var treatdata = db.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x).FirstOrDefault();
                    obj.PharmacistName = db.Doctors.Where(x => x.Id == item.DoctorId).Select(x => x.Name).FirstOrDefault();
                    obj.DocterName = db.Doctors.Where(x => x.Id == treatdata.DoctorId).Select(a => a.Name).FirstOrDefault();
                    obj.Department = db.Departments.Where(x => x.DepartmentId == treatdata.DepartmentId).Select(a => a.Name).FirstOrDefault();
                    obj.Notes = item.Notes;
                    obj.DailyDetectionId = item.DailyDetectionId;
                    obj.OrderDateAndTime = item.OrderDateAndTime;
                    obj.DoneDateAndTime = item.DoneDateAndTime;
                    lit.Add(obj);
                }
                return lit;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Get Medicine By Id
        public MedicineViewModel GetByID(int id)
        {
            var data = db.Medicine.Where(x => x.Id == id).First();
            var Medicine = mapper.Map<MedicineViewModel>(data);
            return Medicine;
        }

        #endregion

        #region Get Medicine Price By Name
        public decimal GetPrie(string name)
        {
            var data = db.Medicine.Where(r => r.Name == name).First();
            return data.Price;
        }

        #endregion

        #region Edit Medicine
        public bool Update(MedicineViewModel medicine)
        {
            var data = db.Medicine.Where(r => r.Name == medicine.Name && r.Id != medicine.Id).ToList();
            if (data == null || data.Count == 0)
            {
                var data1 = mapper.Map<Medicine>(medicine);
                db.Entry(data1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
