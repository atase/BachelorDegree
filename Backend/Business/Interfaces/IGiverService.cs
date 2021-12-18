
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IGiverService : IService<Receiver>
    {
        Task<Giver> Register(Giver giver);
        Task<Giver> GetInformations(int id);
    }
}
