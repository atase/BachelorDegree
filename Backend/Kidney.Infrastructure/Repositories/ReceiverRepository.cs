using Kidney.Core.Entities;
using Kidney.Core.Repositories;
using Kidney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidney.Infrastructure.Repositories.Base
{
    public class ReceiverRepository : Repository<Receiver>, IReceiverRepository
    {
        public ReceiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Receiver>> GetReceiverByFirstName(string firstName)
        {
            return await _applicationContext.Receivers.Where(r => r.FirstName == firstName).ToListAsync();
        }
    }
}
