using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctors.Data.Infrastruture;
using Doctors.Data.Repository;
using Doctors.Models;

namespace Doctors.Business
{
    public interface IUserBus
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> AddUser(User User);
        Task<bool> ValidateUser(User user);
        Task<bool> IsUserNameExist(User user);
    }

    public class UserBus : IUserBus
    {
        private IRepositoryWrapper _repo { get; set; }

        public UserBus(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public async Task<bool> ValidateUser(User user)
        {
            var res = await _repo.User.SelectAsync(x => x.UserName == user.UserName && x.Password == user.Password) != null;

            return res;
        }

        public async Task<bool> IsUserNameExist(User user)
        {
            var res = await _repo.User.SelectAsync(x => x.UserName == user.UserName) != null;

            return res;
        }

        public async Task<User> AddUser(User User)
        {
            var res = await _repo.User.CreateAsync(User);
            await _repo.User.SaveAsync();
            return res;
        }

        public async Task<User> GetUser(int id)
        {
            var res = await _repo.User.SelectAsync(id);
            return res;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var res = await _repo.User.SelectAsync();
            return res;
        }
    }
}
