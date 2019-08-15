using System;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Data.Repository
{
    public interface ILanguageRepository : IRepository<Language>
    {
    }

    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
