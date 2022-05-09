using DAL.Database;
using DAL.Entities;
using DAL.Models;
using Microsoft.AspNetCore.SignalR;
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
        public int Create(string[] Lab, int DealyDetctionId)
        {
            foreach (var item in Lab)
            {
                if (item != null)
                {
                    PatientLab obj = new PatientLab();
                    obj.DailyDetectionId = DealyDetctionId;
                    obj.LabId = context.Lab.Where(x => x.Name == item).Select(x => x.Id).FirstOrDefault();
                    obj.State = false;
                    obj.OrderDateAndTime = DateTime.Now;
                    context.PatientLab.Add(obj);
                }
                
            }
            try
            {
                context.SaveChanges();
                return 0;
            }
            catch (Exception)
            {

                return 1;
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
                OldData.OrderDateAndTime = DateTime.Now;
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
                var data = context.PatientLab
                                  .OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == true && (context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(a => a.PatientId).FirstOrDefault()) == id);

                return data
                .Select(x => new PatientLabViewModel
                                       {
                                           Id = x.Id,
                                           //PatientId = x.PatientId,
                                           //DoctorId = x.DoctorId,
                                           LapName = context.Lab.Where(y => y.Id == x.LabId).Select(y => y.Name).FirstOrDefault(),
                                           DateAndTime = x.DoneDateAndTime,
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
                                        LapName = context.Lab.Where(y=>y.Id==x.LabId).Select(y=>y.Name).FirstOrDefault(),
                                        DoctorName=context.Doctors.Where(u=>u.Id==x.DoctorId).Select(u=>u.Name).FirstOrDefault(),
                                        DateAndTime = x.DoneDateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo,
                                        DailyDetectionId=x.DailyDetectionId

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
        #region Get the Last Come
        public IEnumerable<PatientLabViewModel> GetTheLast(int id)
        {
            try
            {
                //var DailyDetectionId = context.DailyDetection.Where(x => x.PatientId == id);
                var a = context.PatientLab
                                .OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == true && (context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(a => a.PatientId).FirstOrDefault()) == id);

                var b = a.Max(x => x.DailyDetectionId);
                return context.PatientLab.Where(x=>x.DailyDetectionId==b)
                .Select(x => new PatientLabViewModel
                {
                    Id = x.Id,
                    //PatientId = x.PatientId,
                    //DoctorId = x.DoctorId,
                    LapName = context.Lab.Where(y => y.Id == x.LabId).Select(y => y.Name).FirstOrDefault(),
                    DateAndTime = x.OrderDateAndTime,
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
        #region Get this Labs
        public IEnumerable<PatientLabViewModel> GetThesessionlab(int id)
        {
            try
            {
                var PatientLab = context.PatientLab.Where(x => x.DailyDetectionId == id)
                                    .Select(x => new PatientLabViewModel
                                    {
                                        Id = x.Id,
                                        //PatientId = x.PatientId,
                                        
                                        LapName = context.Lab.Where(y=>y.Id==x.LabId).Select(x=>x.Name).FirstOrDefault(),
                                        DateAndTime = x.OrderDateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo
                                    });
                                    
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
