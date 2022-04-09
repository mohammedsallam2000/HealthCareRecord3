using AutoMapper;
using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RepologeyServices
{
    public class RepologeyServices : IRepologeyServices
    {
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;

        public RepologeyServices(AplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public bool Add(RadiologyViewModel Repologey)
        {
            var data=db.Radiology.Where(r => r.Name == Repologey.Name).ToList();
            if (data==null||data.Count==0)
            {
                var a = mapper.Map < Radiology >(Repologey);
                db.Radiology.Add(a);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.Radiology.Where(x => x.Id == id).FirstOrDefault();
                data.Delete = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<RadiologyViewModel> GetAll()
        {
            List<RadiologyViewModel> list = new List<RadiologyViewModel>();
            foreach (var item in db.Radiology.Where(x=>x.Delete==false))
            {
                var data=mapper.Map<RadiologyViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        public IEnumerable<RadiologyViewModel> GetAllDeletd()
        {
            List<RadiologyViewModel> list = new List<RadiologyViewModel>();
            foreach (var item in db.Radiology.Where(x => x.Delete == true))
            {
                var data = mapper.Map<RadiologyViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        public RadiologyViewModel GetByID(int id)
        {
            var data=db.Radiology.Where(x=>x.Id==id).First();
            var Radiologey = mapper.Map<RadiologyViewModel>(data);
            return Radiologey;
        }

        public decimal GetSalery(string name)
        {
            var data = db.Radiology.Where(x => x.Name == name).FirstOrDefault();
            return data.Price;
        }

        public bool Update(RadiologyViewModel Repologey)
        {
            var data = db.Radiology.Where(r => r.Name == Repologey.Name&&r.Id!=Repologey.Id).ToList();
            if (data == null || data.Count == 0)
            {
                var data1 = mapper.Map<Radiology>(Repologey);
                db.Entry(data1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool UpdateDelete(int id)
        {

            try
            {
                var data = db.Radiology.Where(x => x.Id == id).FirstOrDefault();
                data.Delete = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
