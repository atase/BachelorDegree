
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kidney.DataAccess.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        abstract Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> Include<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class;
    }
}
