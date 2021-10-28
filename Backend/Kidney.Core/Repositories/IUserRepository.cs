using Kidney.Core.Entities;
using Kidney.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kidney.Core.Repositories
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<IEnumerable<User>> GetUserByEmail(string email);
    }
}
