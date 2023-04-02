using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models.vacation;
using AutoMapper;
using DAL.Entities.vacation;
using AutoMapper.QueryableExtensions;

namespace BLL.Services._1Vacation.VacationServices.VacationServices

{
    public class VacationPlainSevice : IVacationServices
    {
        #region Fields
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public VacationPlainSevice(AplicationDbContext db, IMapper mapper)
        {

            this.db = db;
            this.mapper = mapper;
        }

        public bool Add(VacationPlainViewModel model)
        {
            try
            {
                var data = mapper.Map<vacationPlan>(model);
                db.SaveChanges();

                return true;

            }
            catch (Exception)
            {

            return false;

            }



        }

        public bool Cancel(int id)
        {
            var  data=db.vacationPlans.Where(plan => plan.Id == id).FirstOrDefault();
            if (data!=null)
            {
                db.vacationPlans.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<VacationPlainViewModel> GetAll()
        {
            return db.vacationPlans.ProjectTo<VacationPlainViewModel>(mapper.ConfigurationProvider);

        }

        public VacationPlainViewModel GetByID(int id)
        {
            var data = db.vacationPlans.Where(x => x.Id == id).FirstOrDefault();
           var data1=mapper.Map<VacationPlainViewModel>(data);
            return data1;
        }

        public bool Update(VacationPlainViewModel model)
        {
            var data = mapper.Map<vacationPlan>(model);
            
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        #endregion


    }
}
