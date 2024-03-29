﻿using DAL.Database;
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

        public int Create(string[] Radiology, int DailyDetectionId)
        {
            try
            {
                foreach (var item in Radiology)
                {
                    if (item != null)
                    {
                        PatientRediology obj = new PatientRediology();
                        obj.DailyDetectionId = DailyDetectionId;
                        obj.RadiologyId = context.Radiology.Where(x => x.Name == item).Select(x => x.Id).FirstOrDefault();
                        obj.State = false;
                        obj.OrderDateAndTime = DateTime.Now;
                        context.PatientRediology.Add(obj);
                    }
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

        #region Get Patient Rediology
        public PatientRediologyViewModel GetRediology(int id)
        {
            try
            {
                var PatientRediology = context.PatientRediology.Where(x => x.Id == id)
                                    .Select(x => new PatientRediologyViewModel
                                    {
                                        Id = x.Id,
                                        //PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault(),
                                        DoctorNamework = context.Doctors.Where(u => u.Id == x.DoctorId).Select(u => u.Name).FirstOrDefault(),
                                        DateAndTime = x.DoneDateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo,
                                        DailyDetectionId = x.DailyDetectionId
                                    })
                                    .FirstOrDefault();
                return PatientRediology;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Edit Patient Radiology ( Results of test )
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

        #region Edit Patient Radiology ( Results of Radiology )
        public async Task<int> Edit(PatientRediologyViewModel model)
        {
            try
            {
                var OldData = context.PatientRediology.FirstOrDefault(x => x.Id == model.Id);
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

        #region Get all Patient Rediology
        public IEnumerable<PatientRediologyViewModel> GetAll(int id)
        {
            try
            {
                var PatientRediology = context.PatientRediology.OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == true && context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(y => y.PatientId).First() == id)
                                   .Select(x => new PatientRediologyViewModel
                                   {
                                       Id = x.Id,
                                       DoctorNamework = context.Doctors.Where(a => a.Id == x.DoctorId).Select(a => a.Name).FirstOrDefault(),

                                       DoctorNameorder = context.Doctors.Where(z => z.Id == context.DailyDetection.Where(a => a.Id == x.DailyDetectionId).Select(a => a.DoctorId).FirstOrDefault()).Select(z => z.Name).FirstOrDefault(),

                                       DateAndTime = x.OrderDateAndTime,
                                       Document = x.Document,
                                       Photo = x.Photo,
                                       RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault()

                                   });

                return PatientRediology;
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
                var PatientRediology = context.PatientRediology.OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == true && context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(y => y.PatientId).First() == id)
                                    .Select(x => new PatientRediologyViewModel
                                    {
                                        Id = x.Id,
                                        //PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        RadiologyId = x.RadiologyId,
                                        DateAndTime = x.OrderDateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo,
                                        RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault()

                                    })
                                    .FirstOrDefault();
                return PatientRediology;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get session rediology
        public IEnumerable<PatientRediologyViewModel> Getsession(int id)
        {
            try
            {
                var PatientRediology = context.PatientRediology.Where(x => x.DailyDetectionId == id)
                                    .Select(x => new PatientRediologyViewModel
                                    {
                                        Id = x.Id,
                                        //PatientId = x.PatientId,
                                        DoctorId = x.DoctorId,
                                        RadiologyId = x.RadiologyId,
                                        DateAndTime = x.OrderDateAndTime,
                                        Document = x.Document,
                                        Photo = x.Photo,
                                        RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault()

                                    });

                return PatientRediology;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get The Last Rediology
        public IEnumerable<PatientRediologyViewModel> GettheLast(int id)
        {
            var data = context.PatientRediology.OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == true && context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(y => y.PatientId).First() == id).Max(x => x.DailyDetectionId);
            return context.PatientRediology.Where(x => x.DailyDetectionId == data)
                .Select(x => new PatientRediologyViewModel
                {
                    Id = x.Id,
                    //PatientId = x.PatientId,
                    DoctorId = x.DoctorId,
                    RadiologyId = x.RadiologyId,
                    DateAndTime = x.OrderDateAndTime,
                    Document = x.Document,
                    Photo = x.Photo,
                    RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault()


                }); ;
        }

        public IEnumerable<PatientRediologyViewModel> GetAllUnActive(int id)
        {
            try
            {
                var PatientRediology = context.PatientRediology.OrderByDescending(x => x.DailyDetectionId).Where(x => x.State == false && context.DailyDetection.Where(y => y.Id == x.DailyDetectionId).Select(y => y.PatientId).First() == id)
                                   .Select(x => new PatientRediologyViewModel
                                   {
                                       Id = x.Id,
                                       DoctorNamework = context.Doctors.Where(a => a.Id == x.DoctorId).Select(a => a.Name).FirstOrDefault(),

                                       DoctorNameorder = context.Doctors.Where(z => z.Id == context.DailyDetection.Where(a => a.Id == x.DailyDetectionId).Select(a => a.DoctorId).FirstOrDefault()).Select(z => z.Name).FirstOrDefault(),

                                       DateAndTime = x.OrderDateAndTime,
                                       Document = x.Document,
                                       Photo = x.Photo,
                                       RadiologyName = context.Radiology.Where(y => y.Id == x.RadiologyId).Select(y => y.Name).FirstOrDefault()

                                   });

                return PatientRediology;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

    }
}
