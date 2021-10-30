using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kidney.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
