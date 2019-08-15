using System;
using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class MedicalSchool
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
