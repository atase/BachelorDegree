
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kidney.DataAccess.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<T> Add(T entity)
        {
            await _applicationContext.Set<T>().AddAsync(entity);
            await _applicationContext.SaveChangesAsync();

            return entity; 
        }
        public async Task Delete(T entity)
        {
            _applicationContext.Set<T>().Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }
        public async Task<List<T>> GetAll()
        {
            return await _applicationContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _applicationContext.Set<T>().FindAsync(id);
        }
        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Include<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            IQueryable<T> result = null;
            foreach (var include in includes)
            {
                result = query.Include(include);
            }

            return result;
        }

    }
}
