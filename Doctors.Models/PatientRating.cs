using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Models
{
    public class PatientRating
    {
        public int DoctorId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
