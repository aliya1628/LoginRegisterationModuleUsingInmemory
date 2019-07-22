using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegistrationDemo.ViewModels.Register
{
    public class AddUserVM
    {
        [Required(ErrorMessage = "Please enter the user name.")]
        [StringLength(50, ErrorMessage = "The username must be less than {1} characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        [StringLength(50, ErrorMessage = "The password must be less than {1} characters.")]
        public string Password { get; set; }
        
    }
}