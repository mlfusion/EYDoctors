using System;
namespace Doctors.SPA.Dtos
{
    public class PatientRatingDto
    {
        public int DoctorId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}
