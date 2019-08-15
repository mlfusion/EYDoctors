using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Doctors.Models;

namespace Doctors.SPA.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}


