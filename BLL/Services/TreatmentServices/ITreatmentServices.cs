﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.TreatmentServices
{
    public interface ITreatmentServices
    {
        string GetNotes(int id);
    }
}
