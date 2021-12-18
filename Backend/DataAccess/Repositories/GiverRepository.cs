using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces;
using Kidney.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kidney.Infrastructure.Repositories
{
    public class GiverRepository : Repository<Giver>, IGiverRepository
    {
        public GiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Giver>> GetGiverByFirstName(string firstName)
        {
            return await _applicationContext.Givers
                .Where(g => g.FirstName == firstName)
                .ToListAsync();
        }

        public async Task<Giver> GetGiverInformations(int id)
        {
            return _applicationContext.Givers
                .Where(g => g.Id == id)
                .Include("Race")
                .FirstOrDefault();
        }
            
    }
}
