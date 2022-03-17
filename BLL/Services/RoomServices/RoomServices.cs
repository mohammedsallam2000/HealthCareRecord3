using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RoomServices
{
    public class RoomServices : IRoomServices
    {
        private readonly AplicationDbContext db;

        public RoomServices(AplicationDbContext db)
        {
            this.db = db;
        }
        public bool Add(RoomVM Room)
        {
            var R=db.Rooms.Where(x=>x.Floor==Room.Floor &&x.Number==Room.Number).ToList();
            if (R==null||R.Count==0)
            {
                Room obj = new Room();
                obj.Number = Room.Number;
                obj.Floor = Room.Floor;
                obj.Delete = Room.Delete;
                db.Rooms.Add(obj);
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
                var Rooms = db.Room.Where(x => x.Id == id).FirstOrDefault();
                Rooms.Delete = false;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public bool UpdateDelete(int id)
        {
            try
            {
                var Rooms = db.Room.Where(x => x.Id == id).FirstOrDefault();
                Rooms.Delete = true;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<RoomVM> GetAll()
        {
            List<RoomVM> rooms = new List<RoomVM>();
            foreach (var item in db.Rooms.Where(x=>x.Delete==true))
            {
                RoomVM obj = new RoomVM();
                obj.Id = item.Id;
                obj.Floor = item.Floor;
                obj.Number=item.Number;
                obj.Delete=item.Delete;

                rooms.Add(obj);
            }
            return rooms;
        }
        public IEnumerable<RoomVM> GetAllUnUsedRoom()
        {
            List<RoomVM> rooms = new List<RoomVM>();
            foreach (var item in db.Rooms.Where(x => x.Delete == false))
            {
                RoomVM obj = new RoomVM();
                obj.Id = item.Id;
                obj.Floor = item.Floor;
                obj.Number = item.Number;
                obj.Delete = item.Delete;

                rooms.Add(obj);
            }
            return rooms;
        }

        public RoomVM GetByID(int id)
        {
            var Room = db.Room.Where(x => x.Id == id).FirstOrDefault();
            RoomVM Rooms = new RoomVM();
            Rooms.Id = id;
            Rooms.Floor = Room.Floor;
            Rooms.Number = Room.Number;
            Rooms.Delete= Room.Delete;
            return Rooms;
        }

        public bool Update(RoomVM Room)
        {
           
            var R = db.Rooms.Where(x => x.Floor == Room.Floor && x.Number == Room.Number&& x.Id!=Room.Id).ToList();
            if (R == null||R.Count==0)
            {
                var Rooms = db.Room.Where(x => x.Id == Room.Id).FirstOrDefault();
                Rooms.Floor = Room.Floor;
                Rooms.Number = Room.Number;
                Rooms.Delete = Room.Delete;
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
