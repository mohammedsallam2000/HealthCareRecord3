using AutoMapper;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Patient, PatiantVM>();
            CreateMap<PatiantVM, Patient>(); 

        }
    }
}
 