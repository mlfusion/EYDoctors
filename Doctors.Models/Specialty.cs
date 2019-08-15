using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual DoctorSpecialty DoctorSpecialty { get; set; }
    }

    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
