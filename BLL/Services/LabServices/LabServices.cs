using AutoMapper;
using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.LabServices
{
    public class LabServices : ILabServices
    {
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;

        public LabServices(AplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public bool Add(LabViewModel lab)
        {
            var data = db.Lab.Where(r => r.Name == lab.Name).ToList();
            if (data == null || data.Count == 0)
            {
                var a = mapper.Map<Lab>(lab);
                db.Lab.Add(a);
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
                var data = db.Lab.Where(x => x.Id == id).FirstOrDefault();
                data.Delete = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<LabViewModel> GetAll()
        {
            List<LabViewModel> list = new List<LabViewModel>();
            foreach (var item in db.Lab.Where(x => x.Delete == false))
            {
                var data = mapper.Map<LabViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        public IEnumerable<LabViewModel> GetAllDeletd()
        {
            List<LabViewModel> list = new List<LabViewModel>();
            foreach (var item in db.Lab.Where(x => x.Delete == true))
            {
                var data = mapper.Map<LabViewModel>(item);
                list.Add(data);

            }
            return list;
        }

        public LabViewModel GetByID(int id)
        {
            var data = db.Lab.Where(x => x.Id == id).First();
            var lab = mapper.Map<LabViewModel>(data);
            return lab;
        }

        public decimal Getprice(string name)
        {
            var data = db.Lab.Where(x => x.Name == name).First();
            return data.Price;
        }

        public bool Update(LabViewModel lab)
        {
            var data = db.Lab.Where(r => r.Name == lab.Name&&r.Id!=lab.Id).ToList();
            if (data == null || data.Count == 0)
            {
                var data1 = mapper.Map<Lab>(lab);
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
                var data = db.Lab.Where(x => x.Id == id).FirstOrDefault();
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
