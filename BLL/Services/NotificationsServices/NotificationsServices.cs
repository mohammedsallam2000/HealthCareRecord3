using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services.NotificationsServices
{
    public class NotificationsServices : INotificationsServices
    {
        private readonly AplicationDbContext db;
        public NotificationsServices(AplicationDbContext db)
        {
            this.db = db;
        }
        public int Create(string name)
        {
            if (name != null)
            {
                Notifications obj = new Notifications();
                obj.Data = name;
                db.Notifications.Add(obj);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0; 
            }
           
        }



        public void Confirm(string name)
        {

            var ss = db.Notifications.Where(x => x.Data == name).FirstOrDefault();
            ss.Status = true;
            db.SaveChanges();

        }
        public void Cancel(string name)
        {

            var ss = db.Notifications.Where(x => x.Data == name).FirstOrDefault();
            ss.Status = false;
            db.SaveChanges();
        }

        public string GetAll(string name)
        {
            try
            {
               return db.Notifications.Where(x => x.Status == true && x.Data == name).Select(x => x.Data).FirstOrDefault();
            }
            catch (Exception)
            {

                return "";
            }

           


        }
        //public IEnumerable<NotificationsViewModel> GetAll(string name)
        //{

        //        return db.Notifications.Select(x => new NotificationsViewModel
        //        {
        //            Data = x.Data
        //        }).Where(x => x.Status == true && x.Data == name);


        //}
    }
}
