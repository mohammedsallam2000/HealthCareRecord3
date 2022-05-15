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

        public IEnumerable<NotificationsViewModel> GetAll()
        {
            foreach (var item in db.Notifications)
            {
                //if (item.Status==0)
                //{

                //}
                 
            }
          return  db.Notifications.Select(x => new NotificationsViewModel
            {
                Data = x.Data
            });
        }
    }
}
