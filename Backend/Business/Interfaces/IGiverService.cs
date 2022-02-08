
using Business.Models;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IGiverService : IService<Receiver>
    {
        Task<Giver> Register(Giver giver);
        Task<Giver> GetInformations(int id);
        Task<IEnumerable<Giver>> FilterGivers(GiverFilter filters);
        Task<string> DeleteGiver(int id);
        Task<IEnumerable<Giver>> GetAll();
        Task<string> UpdateGiver(int id, Giver giver);
    }
}
