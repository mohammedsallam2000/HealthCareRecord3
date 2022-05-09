using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientSurgeryServices
{
    public class PatientSurgeryServices : IPatientSurgeryServices
    {
        #region Fields
        private readonly AplicationDbContext context;
        #endregion

        #region Ctor
        public PatientSurgeryServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create Patinet Surgery(Order)
        public int Create(string surgeryName, int id)
        {
            try
            {
                PatientSurgery obj = new PatientSurgery();
               
                obj.SurgeryId =context.Surgery.Where(x=>x.Name==surgeryName).Select(x=>x.Id).FirstOrDefault();
                obj.State = false;
                obj.DailyDetectionId = id;
                obj.OrderDateAndTime = DateTime.Now;
                context.PatientSurgery.Add(obj);
                int res =  context.SaveChanges();
                if (res > 0)
                {
                    return obj.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Edit Patient Surgery 
        public async Task<int> Edit(PatientSurgeryViewModel model)
        {
            try
            {
                var OldData = context.PatientSurgery.FirstOrDefault(x => x.Id == model.Id);
                OldData.State = true;
                OldData.DoneDateAndTime = DateTime.Now;
                //OldData.Time = DateTime.Now.;
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

        #region Get all Patient Surgery
        public IEnumerable<PatientSurgeryViewModel> GetAll(int id)
        {
            try
            {
                return context.PatientSurgery
                                .Where(x => x.State == true && x.PatientId == id)
                                       .Select(x => new PatientSurgeryViewModel
                                       {
                                           Id = x.Id,
                                           PatientId = x.PatientId,
                                           DoctorId = x.DoctorId,
                                           NurseId = x.NurseId,
                                           SurgeryId = x.SurgeryId,
                                           OrderDateAndTime = x.OrderDateAndTime,
                                           SurgeryName= context.Surgery.Where(y => y.Id == x.SurgeryId).Select(y => y.Name).FirstOrDefault(),
                                           State = x.State
                                       });
            }
            catch (Exception)
            {
                return null;
            }
        }


        #endregion
        #region GetAllSurgery
        public IEnumerable<SurgeryViewModel> GetAll()
        {
            return context.Surgery.Select(x => new SurgeryViewModel
            {

                Name = x.Name,

            });
        }
        #endregion

        #region Get Patient Surgery
        public PatientSurgeryViewModel GetByID(int id)
        {
            try
            {
                var PatientLab = context.PatientSurgery.Where(x => x.Id == id)
                                    .Select(x => new PatientSurgeryViewModel
                                    {
                                        Id = x.Id,
                                        PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        NurseId = x.NurseId,
                                        SurgeryId = x.SurgeryId,
                                        OrderDateAndTime = x.OrderDateAndTime,
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
