
using Business.Models;
using Kidney.Business.Models;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface ICompatibilityService
    {
        Task<Compatibility<Giver, Receiver>> GetCompatibilitiesForGivers();
        Task<Compatibility<Receiver, Giver>> GetCompatibilitiesForReceivers();
        Task<Compatibility<Giver, Receiver>> GetCompatibilitiesForGiver(int id);
        Task<Compatibility<Receiver, Giver>> GetCompatibilitiesForReceiver(int id);
        Task<Compatibility<Giver, Receiver>> GetCompatibilityScores();
        Task<Compatibility<Giver, Receiver>> GenerateCompatibilityScores();
        Task<Statistics> GetStatistics();
    }
}
