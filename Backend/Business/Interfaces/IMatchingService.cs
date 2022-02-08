
using Business.Models;
using Kidney.Business.Models;
using Kidney.DataAccess.DTOs;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IMatchingService
    {
        Task<Matching> MaximalMatchingGiversToReceivers(int var, Compatibility<Giver, Receiver> compatibilities);
        //Task<Matching<Receiver, Giver>> MaximalMatchingReceiversToGivers(int var);
    }
}
