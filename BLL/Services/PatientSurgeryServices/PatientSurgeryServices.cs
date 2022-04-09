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
        public async Task<int> Create(PatientSurgeryViewModel model)
        {
            try
            {
                PatientSurgery obj = new PatientSurgery();
                obj.PatientId = model.PatientId;
                obj.SurgeryId = model.SurgeryId;
                obj.State = false;
                obj.DoctorId = model.DoctorId;
                int res = await context.SaveChangesAsync();
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
                OldData.Date = DateTime.Now.Date;
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
        public IEnumerable<PatientSurgeryViewModel> GetAll()
        {
            try
            {
                return context.PatientSurgery
                                .Where(x => x.State == true)
                                       .Select(x => new PatientSurgeryViewModel
                                       {
                                           Id = x.Id,
                                           PatientId = x.PatientId,
                                           DoctorId = x.DoctorId,
                                           NurseId = x.NurseId,
                                           SurgeryId = x.SurgeryId,
                                           Date = x.Date,
                                           Time = x.Time,
                                           State = x.State
                                       });
            }
            catch (Exception)
            {
                return null;
            }
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
                                        Date = x.Date,
                                        Time = x.Time,
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
