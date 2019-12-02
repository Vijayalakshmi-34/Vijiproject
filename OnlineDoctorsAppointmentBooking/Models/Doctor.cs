using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentBooking.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Display(Name ="Doctor ID")]
        public long DoctorId { get; set; }

        [Display(Name = "First Name")]
        public string DoctorFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string DoctorLastName { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(Name = "Experience")]
        public byte? Experience { get; set; }

        [Display(Name = "Mobile Number")]
        public long? MobileNumber { get; set; }

        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        [Display(Name = "PassWord")]
        public string PassWord { get; set; }

        [Display(Name = "Is Available")]
        public bool? IsAvailable { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Specialization")]
        public string Specialization { get; set; }
    }
}