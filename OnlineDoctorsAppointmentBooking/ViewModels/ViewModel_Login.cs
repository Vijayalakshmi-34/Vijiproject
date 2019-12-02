using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentBooking.ViewModels
{
    public class ViewModel_Login
    {
        [Required]
        [Display(Name = "User Id / Mail Id")]
        public string UserId { get; set; }

        [Required, StringLength(10, ErrorMessage = "Password should be 5 to 10 characters", MinimumLength = 5)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}