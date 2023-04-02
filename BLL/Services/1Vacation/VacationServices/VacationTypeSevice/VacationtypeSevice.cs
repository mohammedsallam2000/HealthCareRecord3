using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Database;
using DAL.Entities.vacation;
using DAL.Models.vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services._1Vacation.VacationServices.VacationTypeSevice
{
    public class VacationtypeSevice: IVacationTypeSevice
    {
        #region Fields
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public VacationtypeSevice(AplicationDbContext db, IMapper mapper)
        {

            this.db = db;
            this.mapper = mapper;
        }

        public bool Add(VacationTypeViewModel model)
        {
            var data1=db.vacationTypes.FirstOrDefault(x=>x.VacationName.Contains(model.VacationName.Trim()));
            if (data1==null)
            {
                try
                {
                    var data = mapper.Map<VacationType>(model);
                    db.vacationTypes.Add(data);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {

                    return false;

                }
            }
            return false;



        }

        public bool Delete(int id)
        {
            var data = db.vacationTypes.Where(plan => plan.Id == id).FirstOrDefault();
            if (data != null)
            {
                db.vacationTypes.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<VacationTypeViewModel> GetAll()
        {
            return db.vacationTypes.ProjectTo<VacationTypeViewModel>(mapper.ConfigurationProvider);

        }

        public VacationTypeViewModel GetByID(int id)
        {
            var data = db.vacationTypes.Where(x => x.Id == id).FirstOrDefault();
            var data1 = mapper.Map<VacationTypeViewModel>(data);
            return data1;
        }

        public bool Update(VacationTypeViewModel model)
        {
            var data = mapper.Map<VacationType>(model);

            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        #endregion

    }
}
