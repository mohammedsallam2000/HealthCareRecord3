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
        public async Task<int> Create(string[] Lab, int DealyDetctionId)
        {
            foreach (var item in Lab)
            {
                PatientLab obj = new PatientLab();
                obj.DailyDetectionId = DealyDetctionId; 
                obj.LabId = context.Lab.Where(x => x.Name == item).Select(x => x.Id).FirstOrDefault();
                obj.State = false;

                context.PatientLab.Add(obj);
            }
            await context.SaveChangesAsync();

            try
            {
                int res = 0;
               

                if (res > 0)
                {
                    return 1/*obj.Id*/;
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
        public IEnumerable<PatientLabViewModel> GetAll(int id)
        {
            try
            {
                //var DailyDetectionId = context.DailyDetection.Where(x=>x.PatientId==id).Last().Id;
                return context.PatientLab
                                .Where(x => x.State == true && x.DailyDetectionId== id)
                                       .Select(x => new PatientLabViewModel
                                       {
                                           Id = x.Id,
                                           //PatientId = x.PatientId,
                                           //DoctorId = x.DoctorId,
                                           LapName = context.Lab.Where(y => y.Id == x.LabId).Select(y => y.Name).FirstOrDefault(),
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
                                        //PatientId = x.PatientId,
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
