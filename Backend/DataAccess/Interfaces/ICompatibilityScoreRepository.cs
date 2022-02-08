using DataAccess.DTOs;
using DataAccess.Entities;
using Kidney.DataAccess.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICompatibilityScoreRepository : IRepository<CompatibilityScore>
    {
        Task<string> UpdateScore(CompatibilityScoreDto obj);
        Task InsertScore(List<CompatibilityScoreDto> objects);
        Task<IEnumerable<CompatibilityScore>> GetScore(CompatibilityScoreDto obj);
        Task<IEnumerable<CompatibilityScore>> GetScoresForGiver(int id);
        Task<IEnumerable<CompatibilityScore>> GetScoresForReceiver(int id);
        
    }
}
