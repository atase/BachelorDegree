using DataAccess.Interfaces;
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Repositories.Base;

namespace DataAccess.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
