using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
    }

    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
