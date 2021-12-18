
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kidney.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<IEnumerable<User>> GetUserByEmail(string email);
    }
}
