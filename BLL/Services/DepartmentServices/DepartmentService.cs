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
        #region Fields
        private readonly AplicationDbContext db;
        #endregion

        #region Ctor
        public DepartmentService(AplicationDbContext db)
        {

            this.db = db;
        }
        #endregion

        #region Create New Department
        public bool Add(DepartmentViewModel dept)
        {
            try
            {
                Department obj = new Department();
                obj.Name = dept.Name;
                obj.State = true;
                obj.Cancel = false;
                db.Departments.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region Delete Department
        public bool Cancel(int Id)
        {
            try
            {
                var Data = db.PatientRediology.Where(x => x.Id == Id).FirstOrDefault();
                Data.Cancel = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Get All Departments
        public IEnumerable<DepartmentViewModel> GetAll()
        {

            var depts = db.Departments.Select(a => a);
            List<DepartmentViewModel> departments = new List<DepartmentViewModel>();
            foreach (var item in depts)
            {
                if (item.State == false)
                {
                    DepartmentViewModel obj = new DepartmentViewModel();
                    obj.DepartmentId=item.DepartmentId;
                    obj.Name = item.Name;
                    departments.Add(obj);
                }
            }
            return departments;
        }
        #endregion

        #region View Deooartment
        public DepartmentViewModel GetByID(int id)
        {
            Department dept = db.Departments.FirstOrDefault(x => x.DepartmentId == id);
            DepartmentViewModel obj = new DepartmentViewModel();
            obj.DepartmentId = dept.DepartmentId;
            obj.Name = dept.Name;
            return obj;
        }
        #endregion

        #region Update In Department
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
        #endregion
    }
}
