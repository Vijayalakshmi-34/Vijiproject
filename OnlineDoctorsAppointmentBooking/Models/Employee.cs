using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentBooking.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name ="Employee ID")]
        public long SapId { get; set; }

        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        [Display(Name = "Mobile Number")]
        public long? MobileNumber { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}