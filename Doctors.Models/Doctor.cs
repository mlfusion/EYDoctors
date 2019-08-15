using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Doctor
    {
     

            [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Gender { get; set; }
            public int LanguageId { get; set; }
            public int MedicalSchoolId { get; set; }
            public virtual Language Language { get; set; }
            public virtual MedicalSchool MedicalSchool { get; set; }
            public virtual DoctorSpecialty DoctorSpecialty { get; set; }
            public virtual IEnumerable<PatientRating> PatientRating { get; set; }
        
    }
}
