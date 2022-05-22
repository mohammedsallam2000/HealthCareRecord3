using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientRoomServices
{
    public class PatientRoomServices: IPatientRoomServices
    {
        #region Fields
        private readonly AplicationDbContext context;
        #endregion

        #region Ctor
        public PatientRoomServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create Patinet Room(Order)
        public int Create(PatientRoomViewModel model)
        {
            try
            {
                PatientRoom obj = new PatientRoom();
                obj.DailyDetectionId = model.DailyDetectionId;
                obj.RoomId = model.RoomId;
                obj.StartTime = model.StartTime;
                obj.EndTime=model.EndTime;
                obj.State = false;
                context.PatientRoom.Add(obj);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    return obj.Id;
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Edit Patient Room 
        public async Task<int> Edit(PatientRoomViewModel model)
        {
            try
            {
                var OldData = context.PatientRoom.FirstOrDefault(x => x.Id == model.Id);
                OldData.State = true;
                OldData.StartTime = model.StartTime;
                OldData.EndTime = model.EndTime;
                OldData.NurseId = model.NurseId;
                OldData.DoctorId = model.DoctorId;
                int res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return OldData.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region Get all Patient Room
        public IEnumerable<PatientRoomViewModel> GetAll(int id)
        {
            try
            {
                return context.PatientRoom
                                .Where(x => x.State == true && (context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(a => a.PatientId).FirstOrDefault()) == id)
                                       .Select(x => new PatientRoomViewModel
                                       {
                                           Id = x.Id,
                                           DoctorId = x.DoctorId,
                                           NurseId = x.NurseId,
                                           RoomId = x.RoomId,
                                           StartTime = x.StartTime,
                                           EndTime = x.EndTime,
                                           RoomNumber = context.Room.Where(y=>y.Id==x.RoomId).Select(y=>y.Number ).FirstOrDefault(),
                                           RoomFloor= context.Room.Where(y => y.Id == x.RoomId).Select(y => y.Floor).FirstOrDefault(),
                                           State = x.State
                                       });
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get Patient Room
        public PatientRoomViewModel GetByID(int id)
        {
            try
            {
                var PatientLab = context.PatientRoom.Where(x => x.Id == id)
                                    .Select(x => new PatientRoomViewModel
                                    {
                                        Id = x.Id,
                                        //PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        NurseId = x.NurseId,
                                        RoomId = x.RoomId,
                                        StartTime = x.StartTime,
                                        EndTime = x.EndTime,
                                        State = x.State
                                    })
                                    .FirstOrDefault();
                return PatientLab;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
