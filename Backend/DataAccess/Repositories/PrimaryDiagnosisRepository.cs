using DataAccess.Interfaces;
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Repositories.Base;

namespace DataAccess.Repositories
{
    public class PrimaryDiagnosisRepository : Repository<PrimaryDiagnosis>, IPrimaryDiagnosisRepository
    {
        public PrimaryDiagnosisRepository(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
