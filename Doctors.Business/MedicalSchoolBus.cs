using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Models;
using System.Linq;

namespace Doctors.Business
{
    public interface IMedicalSchoolBus
    {
        Task<IEnumerable<MedicalSchool>> GetMedicalSchools();
        Task<MedicalSchool> GetMedicalSchool(int id);
        Task<MedicalSchool> AddMedicalSchool(MedicalSchool MedicalSchool);
    }


    public class MedicalSchoolBus : IMedicalSchoolBus
    {
        public IRepositoryWrapper _repo { get; set; }

        public MedicalSchoolBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<MedicalSchool> AddMedicalSchool(MedicalSchool medicalSchool)
        {
            var res = await _repo.MedicalSchool.CreateAsync(medicalSchool);
            await _repo.MedicalSchool.SaveAsync();
            return res;
        }

        public async Task<MedicalSchool> GetMedicalSchool(int id)
        {
            var res = await _repo.MedicalSchool.SelectAsync(id);        
            return res;
        }

        public async Task<IEnumerable<MedicalSchool>> GetMedicalSchools()
        {
            var res = await _repo.MedicalSchool.SelectAsync();
            res = res.OrderBy(x => x.Name);
            return res;
        }
    }
}
