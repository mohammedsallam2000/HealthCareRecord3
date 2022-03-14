using BLL.Helper;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailViewModel model)
        {
            TempData["Msg"] = MailSender.SendMail(model);
            ModelState.Clear();
            return View();
        }
    }
}
