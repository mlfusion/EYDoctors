using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Business
{
    public interface IPatientRatingBus
    {
        Task<IEnumerable<PatientRating>> GetPatientRatings();
        Task<PatientRating> GetPatientRating(int id);
        Task<PatientRating> AddPatientRating(PatientRating PatientRating);
    }


    public class PatientRatingBus : IPatientRatingBus
    {
        public IRepositoryWrapper _repo { get; set; }

        public PatientRatingBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<PatientRating> AddPatientRating(PatientRating PatientRating)
        {
            var res = await _repo.PatientRating.CreateAsync(PatientRating);
            await _repo.PatientRating.SaveAsync();
            return res;
        }

        public async Task<PatientRating> GetPatientRating(int id)
        {
            return await _repo.PatientRating.SelectAsync(id);
        }

        public async Task<IEnumerable<PatientRating>> GetPatientRatings()
        {
            return await _repo.PatientRating.SelectAsync();
        }
    }
}
