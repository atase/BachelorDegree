
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.DataAccess.Interfaces
{
    public interface IGiverRepository : IRepository<Giver>
    {
        Task<IEnumerable<Giver>> GetGiverByFirstName(string firstName);
        Task<Giver> GetGiverInformations(int id);
    }

}
