using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentSevice
    {
      //  public AplicationDbdb context = new AplicationDbContext();
        private readonly AplicationDbContext db;

        public DepartmentService(AplicationDbContext db)
        {
        
            this.db = db;
        }
        public bool Add(DepartmentViewModel dept)
        {
            try
            {
                Department obj = new Department();
                obj.Name = dept.Name;
                    db.Departments.Add(obj);
                    db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var DeletedObject = db.Departments.FirstOrDefault(x => x.DepartmentId == id);
                //DeletedObject.IsActive = true;
                 db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IQueryable<DepartmentViewModel> GetAll()
        {

            var depts = db.Departments.Select(a => new DepartmentViewModel { DepartmentId = a.DepartmentId, Name = a.Name });
            //List<DepartmentViewModel> depts = new List<DepartmentViewModel>();
            //foreach (var item in context.Departments)
            //{
            //    DepartmentViewModel obj = new DepartmentViewModel();
            //    obj.DepartmentId = item.DepartmentId;
            //    obj.Name = item.Name;
            //}
            return depts;
        }

        public DepartmentViewModel GetByID(int id)
        {
            Department dept = db.Departments.FirstOrDefault(x => x.DepartmentId == id);
            DepartmentViewModel obj = new DepartmentViewModel();
            obj.DepartmentId = dept.DepartmentId;
            obj.Name = dept.Name;
            return obj;
        }

        public bool Update(DepartmentViewModel dept)
        {
            try
            {
                Department obj = db.Departments.FirstOrDefault(x => x.DepartmentId ==dept.DepartmentId);
                if (obj != null)
                {
                    obj.Name = dept.Name;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
