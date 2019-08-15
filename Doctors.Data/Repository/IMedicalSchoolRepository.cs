using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface IMedicalSchoolRepository : IRepository<MedicalSchool>
    {
    }

    public class MedicalSchoolRepository : Repository<MedicalSchool>, IMedicalSchoolRepository
    {
        public MedicalSchoolRepository(RepositoryContext context) : base(context)
        {

        }
    }

}
