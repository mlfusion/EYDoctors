using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface IPatientRatingRepository : IRepository<PatientRating>
    {
    }

    public class PatientRatingRepository : Repository<PatientRating>, IPatientRatingRepository
    {
        public PatientRatingRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
