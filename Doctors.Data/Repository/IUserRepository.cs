using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
