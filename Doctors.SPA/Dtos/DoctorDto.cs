using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Doctors.Models;

namespace Doctors.SPA.Dtos
{
    public class DoctorDto
    {
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public int MedicalSchoolId { get; set; }
        [Required]
        public int SpecialtyId { get; set; }
    }

    public class DoctorDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public LanguageDto Language { get; set; }
        public MedicalSchoolDto MedicalSchool { get; set; }
        public SpecialtyDto Specialty { get; set; }
        public IEnumerable<PatientRatingDetailDto> PatientRatings { get; set; }
    }

    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MedicalSchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PatientRatingDetailDto
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }

    public class SpecialtyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //public class UserDto
    //{
    //    [Required]
    //    public string Name { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}

}


