using System;
using Doctors.Data.Repository;

namespace Doctors.Data.Infrastruture
{
    public interface IRepositoryWrapper
    {
        IDoctorRepository Doctor { get; }
        ILanguageRepository Language { get; }
        ISpecialtyRepository Specialty { get; }
        IMedicalSchoolRepository MedicalSchool { get; }
        IPatientRatingRepository PatientRating { get; }
        IDoctorSpecialtyRepository DoctorSpecialty { get; }
        IUserRepository User { get; }
    }
}
