using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.shiftServeses
{
    public class ShiftServices : IShiftServeses
    {
        private readonly AplicationDbContext db;

        public ShiftServices(AplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(ShiftViewModel shift)
        {
            Shift obj = new Shift();
            obj.StartShift = shift.StartShift;
            obj.EndShift = shift.EndShift;  
            db.Shifts.Add(obj);
            db.SaveChanges();   
        }

       

        public IEnumerable<ShiftViewModel> GetAll()
        {
           List<ShiftViewModel> list = new List<ShiftViewModel>();
            foreach (var obj in db.Shifts)
            {
                ShiftViewModel shift=new ShiftViewModel();
                shift.StartShift = obj.StartShift;
                shift.EndShift = obj.EndShift;
                shift.Id=obj.Id;
                list.Add(shift);

            }  
            return list;
        }

        public ShiftViewModel GetByID(int id)
        {
            var shift=db.Shifts.Where(x=>x.Id==id).FirstOrDefault();
            ShiftViewModel obj = new ShiftViewModel();
            obj.StartShift=shift.StartShift;
            obj.EndShift=shift.EndShift;
            obj.Id=shift.Id;
            return obj;


        }

        public bool Update(ShiftViewModel shift)
        {
            var shifts = db.Shifts.Where(x => x.Id == shift.Id).FirstOrDefault();
            shifts.StartShift = shift.StartShift;
            shifts.EndShift = shift.EndShift;
            db.SaveChanges();
            return true;
        }
    }
}
