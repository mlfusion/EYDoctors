using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
    }

    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext context) : base(context)
        {

        }
    }

    public interface IDoctorSpecialtyRepository : IRepository<DoctorSpecialty>
    {
    }

    public class DoctorSpecialtyRepository : Repository<DoctorSpecialty>, IDoctorSpecialtyRepository
    {
        public DoctorSpecialtyRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
