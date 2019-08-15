using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doctors.Data.Infrastruture
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> SelectAsync();
        Task<T> SelectAsync(int id);
        Task<T> SelectAsync(Expression<Func<T, bool>> expression);
        Task<T> SelectIncludeAsync(Expression<Func<T, bool>> filter, params string[] includes);
        Task<IEnumerable<T>> SelectIncludeAsync(Expression<Func<T, bool>> filter, T t, params string[] includes);
        Task<T> CreateAsync(T entity);
        void UpdateAsync(T entity);
        void UpdateAsync(Expression<Func<T, bool>> expression);
        void DeleteAsync(T entity);
        void DeleteAsync(int id);
        Task<bool> SaveAsync();
    }
}
