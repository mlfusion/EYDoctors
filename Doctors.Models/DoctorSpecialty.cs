using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Models
{
    public class DoctorSpecialty
    {
        [Key]
        public int DoctorId { get; set; }

        public int SpecialtyId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
