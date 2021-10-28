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
    public class GiverRepository : Repository<Giver>, IGiverRepository
    {
        public GiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Giver>> GetGiverByFirstName(string firstName)
        {
            return await _applicationContext.Givers.Where(g => g.FirstName == firstName).ToListAsync();
        }
    }
}
