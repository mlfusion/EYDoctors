using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Models;

namespace Doctors.Business
{
    public interface ISpecialtyBus
    {
        Task<IEnumerable<Specialty>> GetSpecialtys();
        Task<Specialty> GetSpecialty(int id);
        Task<Specialty> AddSpecialty(Specialty Specialty);
    }


    public class SpecialtyBus : ISpecialtyBus
    {
        public IRepositoryWrapper _repo { get; set; }

        public SpecialtyBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<Specialty> AddSpecialty(Specialty Specialty)
        {
            var res = await _repo.Specialty.CreateAsync(Specialty);
            await _repo.Specialty.SaveAsync();
            return res;
        }

        public async Task<Specialty> GetSpecialty(int id)
        {
            return await _repo.Specialty.SelectAsync(id);
        }

        public async Task<IEnumerable<Specialty>> GetSpecialtys()
        {
            var res = await _repo.Specialty.SelectAsync();
            res = res.OrderBy(x => x.Name);
            return res;
        }
    }
}
