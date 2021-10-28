using Kidney.Core.Entities;
using Kidney.Core.Repositories;
using Kidney.Infrastructure.Data;
using Kidney.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
