using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Models;
using System.Linq;

namespace Doctors.Business
{
    public interface  ILanguageBus
    {
        Task<IEnumerable<Language>> GetLanguages();
        Task<Language> GetLanguage(int id);
        Task<Language> AddLanguage(Language language);
    }


    public class LanguageBus :  ILanguageBus
    {
        public IRepositoryWrapper _repo { get; set; }

        public LanguageBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<Language> AddLanguage(Language language)
        {
            var res = await _repo.Language.CreateAsync(language);
            await _repo.Language.SaveAsync();
            return res;
        }

        public async Task<Language> GetLanguage(int id)
        {
            return await _repo.Language.SelectAsync(id);
        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            var ret = await _repo.Language.SelectAsync();
            ret = ret.OrderBy(x => x.Name);

            return ret;
        }
    }
}
