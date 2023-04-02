using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Entities.EmployeePayment;
using DAL.Entities.UserWork;
using DAL.Models;
using DAL.Models.UserWork;

namespace BLL.Services.EmployeePayment.PaymentWay
{
    public class PaymentWayService : IPaymentWayService
    {
        #region Fields
        private readonly AplicationDbContext db;
        #endregion

        #region Ctor
        public PaymentWayService(AplicationDbContext db)
        {

            this.db = db;
        }
        #endregion

        #region Create New Department
        public bool Add(PaymentViewModel dept)
        {
            try
            {
                Paymentways obj = new Paymentways();
                obj.Name = dept.Name;
                
               
                db.paymentWays.Add(obj);
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
                var Data = db.paymentWays.Where(x => x.Id == Id).FirstOrDefault();
                db.paymentWays.Remove(Data);
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
        public IEnumerable<PaymentViewModel> GetAll()
        {

            var depts = db.paymentWays.Select(a => a);
            List<PaymentViewModel> TypeWork = new List<PaymentViewModel>();
            foreach (var item in depts)
            {

                PaymentViewModel obj = new PaymentViewModel();
                    obj.Id = item.Id;
                    obj.Name = item.Name;
                    TypeWork.Add(obj);
                
            }
            return TypeWork;
        }
        public IEnumerable<PaymentViewModel> GetAllDepartmentForBooking()
        {

            List<PaymentViewModel> TypeWork = new List<PaymentViewModel>();
            foreach (var item in db.paymentWays.ToList())
            {

                PaymentViewModel obj = new PaymentViewModel();
                    obj.Id = item.Id;
                    obj.Name = item.Name;
                    TypeWork.Add(obj);
               
            }
            return TypeWork;
        }

        #endregion

        #region Get Department By Id
        public PaymentViewModel GetByID(int id)
        {
            Paymentways dept = db.paymentWays.FirstOrDefault(x => x.Id == id);
            PaymentViewModel obj = new PaymentViewModel();
            obj.Id = dept.Id;
            obj.Name = dept.Name;
            return obj;
        }
        #endregion

        #region Update In Department
        public bool Update(PaymentViewModel dept)
        {
            try
            {
                var oldData = db.paymentWays.FirstOrDefault(x => x.Id == dept.Id);
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
