using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Data.Repository;
using Doctors.Models;

namespace Doctors.Business
{
    public interface IDoctorBus
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<bool> AddDoctorSpecialty(DoctorSpecialty doctor);
    }

    public class DoctorBus : IDoctorBus
    {
        private IRepositoryWrapper _repo { get; set; }

        public DoctorBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            var res = await _repo.Doctor.CreateAsync(doctor);
            await _repo.Doctor.SaveAsync();
            return res;
        }

        public async Task<bool> AddDoctorSpecialty(DoctorSpecialty doctor)
        {
            await _repo.DoctorSpecialty.CreateAsync(doctor);

            if (await _repo.DoctorSpecialty.SaveAsync())
                return true;
            else
                return false;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var res = await _repo.Doctor.SelectIncludeAsync(x => x.Id == id, "Language", "MedicalSchool", "PatientRating", "DoctorSpecialty");
            return res;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var res = await _repo.Doctor.SelectAsync();
            res = res.OrderBy(x => x.Name);
            return res;
        }
    }
}
