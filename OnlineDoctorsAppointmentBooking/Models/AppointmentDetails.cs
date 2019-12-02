using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentBooking.Models
{
    public class AppointmentDetails
    {
        public int Id { get; set; }

        [Display(Name ="Appointment Number")]
        public long AppointmentNumber { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime? AppointmentDate { get; set; }

        [Display(Name = "Appointment Time")]
        public string AppointmentTime { get; set; }

        [Display(Name = "Booking Status")]
        public string StatusOfBooking { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}