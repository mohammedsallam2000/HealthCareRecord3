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
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;

        public MedicineServices(AplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
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

        public IEnumerable<MedicineViewModel> GetAllEnd()
        {
            List<MedicineViewModel> list = new List<MedicineViewModel>();
            foreach (var item in db.Medicine.Where(x=>x.Count==0))
            {
                var data = mapper.Map<MedicineViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        //public IEnumerable<TreatmentViewModel> GetAllTreatment( int id)
        //{
        //    List<TreatmentViewModel> list = new List<TreatmentViewModel>();
        //    var data = db.Treatment.Where(x => x.DailyDetectionId == db.DailyDetection.Where(x=>x.PatientId==id).Select(x=>x.Id));
        //    foreach (var item in data)
        //    {
        //        TreatmentViewModel obj = new TreatmentViewModel();
        //        obj.DocterName=item.
        //    }
           
                

        //}

        public MedicineViewModel GetByID(int id)
        {
            var data = db.Medicine.Where(x => x.Id == id).First();
            var Medicine = mapper.Map<MedicineViewModel>(data);
            return Medicine;
        }

        public decimal GetPrie(string name)
        {
            var data = db.Medicine.Where(r => r.Name == name).First();
            return data.Price;
        }

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
    }
}
