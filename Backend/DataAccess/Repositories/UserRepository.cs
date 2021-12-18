using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces;
using Kidney.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<User>> GetUserByEmail(string email)
        {
            return await _applicationContext.Users.Where(u => u.Email == email).ToListAsync();
        }
    }
}
