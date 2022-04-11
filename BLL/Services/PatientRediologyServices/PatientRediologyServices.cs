using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientRediologyServices
{
    public class PatientRediologyServices : IPatientRediologyServices
    {
        #region Fields
        private readonly AplicationDbContext context;
        #endregion

        #region Ctor
        public PatientRediologyServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create Patinet Radiology(Order)

        public int Create(string[] Radiology, int patiastId, int DoctorId)
        {
            try
            {
                foreach (var item in Radiology)
                {
                    PatientRediology obj = new PatientRediology();
                    obj.PatientId = patiastId;
                    obj.RadiologyId = context.Radiology.Where(x => x.Name == item).Select(x => x.Id).FirstOrDefault();
                    obj.State = false;
                    obj.DoctorId = DoctorId;
                    context.PatientRediology.Add(obj);
                }
                context.SaveChanges();



                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Edit Patient Lab ( Results of test )
        public async Task<int> Edit(PatientLabViewModel model)
        {
            try
            {
                var OldData = context.PatientLab.FirstOrDefault(x => x.Id == model.Id);
                OldData.State = true;
                OldData.DateAndTime = DateTime.Now;
                OldData.Document = model.Document;
                OldData.Photo = model.Photo;
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

        #region Edit Patient Radiology ( Results of Radiology )
        public async Task<int> Edit(PatientRediologyViewModel model)
        {
            try
            {
                var OldData = context.PatientRediology.FirstOrDefault(x => x.Id == model.Id);
                OldData.State = true;
                OldData.DateAndTime = DateTime.Now;
                OldData.Document = model.Document;
                OldData.Photo = model.Photo;
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

        #region Get all Patient Rediology
        public IEnumerable<PatientRediologyViewModel> GetAll(int id)
        {
            try
            {
                return context.PatientRediology
                                .Where(x => x.State == true && x.PatientId==id)
                                       .Select(x => new PatientRediologyViewModel
                                       {
                                           Id = x.Id,
                                           PatientId = x.PatientId,
                                           DoctorId = x.DoctorId,
                                           RadiologyId = x.RadiologyId,
                                           DateAndTime = x.DateAndTime,
                                           Document = x.Document,
                                           RadiologyName= context.Radiology.Where(y=>y.Id==x.RadiologyId).Select(y=>y.Name).FirstOrDefault(),
                                           Photo = x.Photo
                                       });
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get Patient Rediology
        public PatientRediologyViewModel GetByID(int id)
        {
            try
            {
                var PatientLab = context.PatientRediology.Where(x => x.Id == id)
                                    .Select(x => new PatientRediologyViewModel
                                    {
                                        Id = x.Id,
                                        PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        RadiologyId = x.RadiologyId,
                                        DateAndTime = x.DateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo
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
