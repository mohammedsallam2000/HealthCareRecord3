﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public bool State { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}