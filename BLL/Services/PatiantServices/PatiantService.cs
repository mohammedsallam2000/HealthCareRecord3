using AutoMapper;
using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatiantServices
{
    public class PatiantService : IPatiantService
    {
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;

        public PatiantService(AplicationDbContext db,IMapper mapper )
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(PatiantVM PatiantVM)
        {
            var data=mapper.Map<Patient>( PatiantVM );
            db.Patients.Add(data);
            db.SaveChanges(); 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PatiantVM> Get()
        {
            throw new NotImplementedException();
        }

        public PatiantVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PatiantVM PatiantVM)
        {
            throw new NotImplementedException();
        }
    }
}
