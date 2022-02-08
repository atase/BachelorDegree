using DataAccess.DTOs;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CompatibilityScoreRepository : Repository<CompatibilityScore>, ICompatibilityScoreRepository
    {

        public CompatibilityScoreRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<CompatibilityScore>> GetScore(CompatibilityScoreDto obj)
        {
            var result = _applicationContext.CompatibilityScores.AsQueryable().Where(e => e.GiverId == obj.GiverId && e.ReceiverId == obj.ReceiverId);
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<CompatibilityScore>> GetScoresForGiver(int id)
        {
            var result = _applicationContext.CompatibilityScores.AsQueryable().Where(e => e.GiverId == id);
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<CompatibilityScore>> GetScoresForReceiver(int id)
        {
            var result = _applicationContext.CompatibilityScores.AsQueryable().Where(e => e.ReceiverId == id);
            return result.AsEnumerable();
        }

        public async Task InsertScore(List<CompatibilityScoreDto> objects)
        {
            var existingScores = _applicationContext.CompatibilityScores.AsEnumerable();

            foreach (var score in existingScores) 
            {
                _applicationContext.Remove(score);
            }

            _applicationContext.SaveChanges();

            foreach (var obj in objects)
            {
                _applicationContext.CompatibilityScores.Add(new CompatibilityScore()
                {
                    GiverId = obj.GiverId,
                    ReceiverId = obj.ReceiverId,
                    Score = obj.Score

                });
            }

            _applicationContext.SaveChanges();
        }

        public async Task<string> UpdateScore(CompatibilityScoreDto obj)
        {
            var items = await GetScore(obj);

            foreach (var item in items)
            {
                item.Score = obj.Score;
            }
            _applicationContext.SaveChanges();

            return $"Score updated for giver {obj.GiverId} and receiver {obj.ReceiverId}";
        }
    }
}
