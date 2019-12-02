using OnlineDoctorsAppointmentBooking.Models;
using OnlineDoctorsAppointmentBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookingDoctorsAppointment.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public EmployeeController()
        {
            dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeLogin(ViewModel_Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var employee = dbContext.Employees.FirstOrDefault(e => e.EmailId == loginViewModel.UserId || e.SapId.ToString() == loginViewModel.UserId);
                if (employee == null)
                {
                    loginViewModel.LoginErrorMessage = "Invalid Sap Id or Mail Id";
                    return View("EmployeeLogin", loginViewModel);
                }
                else if (employee.Password == loginViewModel.Password)
                {
                    Session["employee"] = employee;
                    return RedirectToAction("Index");
                }
                else
                {
                    loginViewModel.LoginErrorMessage = "Incorrect Password....Try again!!!!";
                    return View("EmployeeLogin", loginViewModel);
                }
            }
        }
        public ActionResult MyDetails()
        {
            ViewBag.employee = Session["employee"];
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var empInDb = dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (empInDb != null)
            {
                empInDb.EmployeeFirstName = employee.EmployeeFirstName;
                empInDb.EmployeeLastName = employee.EmployeeLastName;
                empInDb.EmailId = employee.EmailId;
                empInDb.Password = employee.Password;
                empInDb.MobileNumber = employee.MobileNumber;
                empInDb.DateOfBirth = employee.DateOfBirth;
                empInDb.BloodGroup = employee.BloodGroup;
                empInDb.Location = employee.Location;
                empInDb.Location = employee.Location;
            }

            dbContext.SaveChanges();
            //Session["employee"] = empInDb;
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult BookAppointment()
        {
            ViewBag.Location = ListCity();
            ViewBag.Specialization = ListSpecialization();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Location = ListCity();
                ViewBag.Specialization = ListSpecialization();
                return View();
            }
            var doctors = dbContext.Doctors.Where(d => d.Location == doctor.Location && d.Specialization == doctor.Specialization && d.IsAvailable == true).ToList();
            if (doctors.Count != 0)
            {
                return View("DisplayDoctors", doctors);
            }
            else
            {
                return Content("Doctors not found");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchByDoctorName(string search)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Location = ListCity();
                ViewBag.Specialization = ListSpecialization();
                return View();
            }
            var doctor = dbContext.Doctors.Where(d => (d.DoctorFirstName.Contains(search) || d.DoctorLastName.Contains(search)) && d.IsAvailable == true).ToList();
            if (doctor.Count != 0)
            {
                return View("DisplayDoctors", doctor);
            }
            else
            {
                return Content("Doctors not found");
            }
        }
        [HttpGet]
        public ActionResult TimeSlots()
        {
            ViewBag.SlotTime = SlotTimings();
            return View();
        }
        [HttpPost]
        public ActionResult TimeSlots(SlotBookingViewModel bookingViewModel)
        {
            return View();
        }
        public ActionResult BookingDetails(int id)
        {
            var bookingDetails = dbContext.AppointmentDetails.Where(b => b.EmployeeId == id).ToList();
            return View(bookingDetails);
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListCity()
        {
            var Location = (from l in dbContext.Doctors.AsEnumerable().GroupBy(l => l.Location)
                            select new SelectListItem
                            {
                                Text = l.Key
                            }).ToList();

            Location.Insert(0, new SelectListItem { Text = "--Select Healthcare Location--", Value = "0", Disabled = true, Selected = true });

            return Location;
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListSpecialization()
        {
            var Specialization = (from s in dbContext.Doctors.AsEnumerable().GroupBy(s => s.Specialization)
                                  select new SelectListItem
                                  {
                                      Text = s.Key
                                  }).ToList();

            Specialization.Insert(0, new SelectListItem { Text = "--Select Specialization--", Value = "0", Disabled = true, Selected = true });

            return Specialization;
        }
        [NonAction]
        public IEnumerable<string> SlotTimings()
        {
            List<string> SlotTime = new List<string>
            {
                "10:00am - 10:30am",
                "10:30am - 11:00am",
                "11:00am - 11:30am",
                "11:30am - 12:00pm",
                "02:30pm - 03:00pm",
                "03:00pm - 03:30pm",
                "03:30pm - 04:00pm",
                "04:00pm - 04:30pm",
                "07:00pm - 07:30pm",
                "07:30pm - 08:00pm",
                "08:00pm - 08:30pm",
                "08:30pm - 09:00pm"
            };
            return SlotTime;
        }
    }
}