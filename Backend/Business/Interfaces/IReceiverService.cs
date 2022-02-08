
using Business.Models;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IReceiverService : IService<Receiver>
    {
        Task<Receiver> Register(Receiver receiver);
        Task<Receiver> GetInformations(int id);
        Task<IEnumerable<Receiver>> FilterReceivers(ReceiverFilter filters);
        Task<IEnumerable<Receiver>> GetAll();
        Task<string> DeleteReceiver(int id);
        Task<string> UpdateReceiver(int id, Receiver receiver);
    }
}
