using BLL.Services.PatientServices;
using BLL.Services.ReservationServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Hubs;

namespace UI.Controllers.HCRWebsite
{
    public class HCRWebsiteController : Controller
    {
        private readonly IPatientServices patient;
        private readonly IReservationServices reserve;
        private readonly IHubContext<RealtimeHub> hub;

        public HCRWebsiteController(IPatientServices patient, IReservationServices Reserve, IHubContext<RealtimeHub> hub)
        {
            this.patient = patient;
            reserve = Reserve;
            this.hub = hub;
        }
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Home(DailyDetectionViewModel Detect)
        {
            var UserId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            Detect.PatientId= patient.PatiantId(UserId);
            var Data = reserve.Add(Detect);
            await hub.Clients.User(Data).SendAsync("newDoctor");
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(PatientViewModel model)
        {
            int id = await patient.Add(model);
            if (id > 0)
            {
                ViewBag.Success = 1;
            }
            TempData["model"] = id;
            TempData.Keep();
            return View();
        }
    }
}
