
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kidney.DataAccess.Interfaces
{
    public interface IReceiverRepository : IRepository<Receiver>
    {
        Task<IEnumerable<Receiver>> GetReceiverByFirstName(string firstName);
        Task<Receiver> GetReceiverInformations(int id);
    }

}
