using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientLabServices
{
    public class PatientLabServices : IPatientLabServices
    {
        #region Fields
        private readonly AplicationDbContext context;
        #endregion

        #region Ctor
        public PatientLabServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create Patinet Lab(Order)
        public async Task<int> Create(PatientLabViewModel model)
        {
            try
            {
                PatientLab obj = new PatientLab();
                obj.PatientId = model.PatientId;
                obj.LabId = model.LabId;
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

        #region Get all Patient Lab
        public IEnumerable<PatientLabViewModel> GetAll()
        {
            try
            {
                return context.PatientLab
                                .Where(x => x.State == true)
                                       .Select(x => new PatientLabViewModel
                                       {
                                           Id = x.Id,
                                           PatientId = x.PatientId,
                                           DoctorId = x.DoctorId,
                                           LabId = x.LabId,
                                           DateAndTime = x.DateAndTime,
                                           Document = x.Document,
                                           Photo = x.Photo
                                       });
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get Patient Lab
        public PatientLabViewModel GetByID(int id)
        {
            try
            {
                var PatientLab = context.PatientLab.Where(x => x.Id == id)
                                    .Select(x => new PatientLabViewModel
                                    {
                                        Id = x.Id,
                                        PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        LabId = x.LabId,
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
