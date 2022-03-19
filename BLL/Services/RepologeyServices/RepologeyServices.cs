using AutoMapper;
using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RepologeyServices
{
    public class RepologeyServices : IRepologeyServices
    {
        private readonly AplicationDbContext db;
        private readonly IMapper mapper;

        public RepologeyServices(AplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public bool Add(RadiologyViewModel Repologey)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RadiologyViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RadiologyViewModel> GetAllUnUsedRoom()
        {
            throw new NotImplementedException();
        }

        public RadiologyViewModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RadiologyViewModel Repologey)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
