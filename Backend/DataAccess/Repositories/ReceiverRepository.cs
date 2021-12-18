using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces;
using Kidney.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.Infrastructure.Repositories.Base
{
    public class ReceiverRepository : Repository<Receiver>, IReceiverRepository
    {
        public ReceiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Receiver>> GetReceiverByFirstName(string firstName)
        {
            return await _applicationContext.Receivers.Where(r => r.FirstName == firstName)
                .ToListAsync();
        }

        public async Task<Receiver> GetReceiverInformations(int id)
        {
            return _applicationContext.Receivers
                .Where(g => g.Id == id)
                .Include("Race")
                .Include("PrimaryDiagnosis")
                .FirstOrDefault();
        }
    }
}
