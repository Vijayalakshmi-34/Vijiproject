using OnlineDoctorsAppointmentBooking.Models;
using OnlineDoctorsAppointmentBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookingDoctorsAppointment.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public DoctorController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorLogin(ViewModel_Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var doctor = dbContext.Doctors.FirstOrDefault(e => e.EmailId == loginViewModel.UserId || e.DoctorId.ToString() == loginViewModel.UserId);
                if (doctor == null)
                {
                    return Content("Invalid Sap Id or Mail Id");
                }
                else if (doctor.PassWord == loginViewModel.Password)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Incorrect Password....Try again!!!!");
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}