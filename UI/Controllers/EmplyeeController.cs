using BLL.Services.EmplyeeServices;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
   
    public class EmplyeeController : Controller
    {
        private readonly IEmplyeeServices emp;

        public EmplyeeController(IEmplyeeServices emp)
        {
            this.emp = emp;
        }

        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmplyeeViewModel EmpVM)
        {
           await emp.Add(EmpVM);
            return View();
        }

    }
}
