using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DoAN.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage="Username cannot be blank.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
     
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank.")]
        [Compare("Password",ErrorMessage="Password and Confirm Password do not match.")]
        public string ConfirmPassord { get; set; }
        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage="Invalid Email.")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


    }
}