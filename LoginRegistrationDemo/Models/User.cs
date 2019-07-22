using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegistrationDemo.Models
{
    public class User
    {
        [Required (ErrorMessage ="Please enter Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}