
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IReceiverService : IService<Receiver>
    {
        Task<Receiver> Register(Receiver receiver);
        Task<Receiver> GetInformations(int id);
    }
}
