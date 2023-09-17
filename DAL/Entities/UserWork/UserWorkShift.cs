﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.UserWork
{
    public class UserWorkShift
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
        public string Department { get; set; }
         public int ShiftWorkId { get; set; }
        public Workshift Workshift { get; set; }
        public bool PaymentYes { get; set; }
        public int Fk_comeandLeaveEmployee { get; set; }
        public comeandLeveEmployye comeandLeveEmployye { get; set; }
    }
}