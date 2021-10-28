using Kidney.Core.Entities;
using Kidney.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kidney.Core.Repositories
{
    public interface IGiverRepository : IRepository<Giver>
    {
        Task<IEnumerable<Giver>> GetGiverByFirstName(string firstName);
    }

}
