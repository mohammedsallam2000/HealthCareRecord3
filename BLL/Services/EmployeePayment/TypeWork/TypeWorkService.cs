using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Entities.UserWork;
using DAL.Models;
using DAL.Models.UserWork;

namespace BLL.Services.EmployeePayment.TypeWork
{
    public class TypeWorkService:ITypeWorkService
    {
        #region Fields
        private readonly AplicationDbContext db;
        #endregion

        #region Ctor
        public TypeWorkService(AplicationDbContext db)
        {

            this.db = db;
        }
        #endregion

        #region Create New Department
        public bool Add(TypeWorkViewModel dept)
        {
            try
            {
                WorkType obj = new WorkType();
                obj.Name = dept.Name;
                
               
                db.typeWorks.Add(obj);
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

        #region Get All TypeWork
        public IEnumerable<TypeWorkViewModel> GetAll()
        {

            var depts = db.typeWorks.Select(a => a);
            List<TypeWorkViewModel> TypeWork = new List<TypeWorkViewModel>();
            foreach (var item in depts)
            {
               
                    TypeWorkViewModel obj = new TypeWorkViewModel();
                    obj.Id = item.Id;
                    obj.Name = item.Name;
                    TypeWork.Add(obj);
                
            }
            return TypeWork;
        }
        public IEnumerable<TypeWorkViewModel> GetAllDepartmentForBooking()
        {

            List<TypeWorkViewModel> TypeWork = new List<TypeWorkViewModel>();
            foreach (var item in db.typeWorks.ToList())
            {
                
                    TypeWorkViewModel obj = new TypeWorkViewModel();
                    obj.Id = item.Id;
                    obj.Name = item.Name;
                    TypeWork.Add(obj);
               
            }
            return TypeWork;
        }

        #endregion

        #region Get Department By Id
        public TypeWorkViewModel GetByID(int id)
        {
            WorkType dept = db.typeWorks.FirstOrDefault(x => x.Id == id);
            TypeWorkViewModel obj = new TypeWorkViewModel();
            obj.Id = dept.Id;
            obj.Name = dept.Name;
            return obj;
        }
        #endregion

        #region Update In Department
        public bool Update(TypeWorkViewModel dept)
        {
            try
            {
                var oldData = db.typeWorks.FirstOrDefault(x => x.Id == dept.Id);
                if (oldData != null)
                {
                    oldData.Name = dept.Name;
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
