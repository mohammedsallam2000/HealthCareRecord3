﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey("User")]
        //public virtual IdentityUser User { get; set; }
        
    }
}
