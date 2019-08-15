using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Doctors.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Data.Infrastruture
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        readonly RepositoryContext _repositoryContext;

        public Repository(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await this._repositoryContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void DeleteAsync(T entity)
        {
            this._repositoryContext.Set<T>().Remove(entity);
        }

        public void DeleteAsync(int id)
        {
            var enitiy = SelectAsync(id);
            this._repositoryContext.Remove(enitiy);
        }

        public async Task<bool> SaveAsync()
        {
            return await this._repositoryContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            var entity = this._repositoryContext.Set<T>();
            return await entity.ToListAsync();
        }

        public async Task<T> SelectAsync(int id)
        {
            var res = await this._repositoryContext.Set<T>().FindAsync(id);
            return res;
        }

        public async Task<T> SelectAsync(Expression<Func<T, bool>> expression)
        {
            return await this._repositoryContext.Set<T>()
            .FirstOrDefaultAsync(expression);
        }

        public async Task<T> SelectIncludeAsync(Expression<Func<T, bool>> filter, params string[] includes)
        {
            IQueryable<T> query = this._repositoryContext.Set<T>();

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> SelectIncludeAsync(Expression<Func<T, bool>> filter, T t, params string[] includes)
        {
            IQueryable<T> query = this._repositoryContext.Set<T>();

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public void UpdateAsync(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
        }

        public void UpdateAsync(Expression<Func<T, bool>> expression)
        {
            var entity = this._repositoryContext.Set<T>()
              .Where(expression);
            this._repositoryContext.Update(entity);
        }

    }
}
