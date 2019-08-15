using System;
using Doctors.Data.Context;
using Doctors.Data.Repository;

namespace Doctors.Data.Infrastruture
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;

        private IDoctorRepository _doctor;
        private IDoctorSpecialtyRepository _doctorSpecialty;
        private ILanguageRepository _language;
        private ISpecialtyRepository _specialty;
        private IMedicalSchoolRepository _medicalSchool;
        private IPatientRatingRepository _patientRating;
        private IUserRepository _user;

        public RepositoryWrapper(RepositoryContext context) 
        {
            this._context = context;
        }

        public IDoctorRepository Doctor
        {
            get
            {
                if (_doctor == null)
                {
                    _doctor = new DoctorRepository(_context);
                }
                return _doctor;
            }
        }

        public IDoctorSpecialtyRepository DoctorSpecialty
        {
            get
            {
                if (_doctorSpecialty == null)
                {
                    _doctorSpecialty = new DoctorSpecialtyRepository(_context);
                }
                return _doctorSpecialty;
            }
        }

        public ILanguageRepository Language
        {
            get
            {
                if (_language == null)
                {
                    _language = new LanguageRepository(_context);
                }
                return _language;
            }
        }

        public ISpecialtyRepository Specialty
        {
            get
            {
                if (_specialty == null)
                {
                   _specialty = new SpecialtyRepository(_context);
                }
                return _specialty;
            }
        }

        public IMedicalSchoolRepository MedicalSchool
        {
            get
            {
                if (_medicalSchool == null)
                {
                    _medicalSchool = new MedicalSchoolRepository(_context);
                }
                return _medicalSchool;
            }
        }


        public IPatientRatingRepository PatientRating
        {
            get
            {
                if (_patientRating == null)
                {
                    _patientRating = new PatientRatingRepository(_context);
                }
                return _patientRating;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }
    }
}
